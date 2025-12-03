using System;
using System.IO;
using GymManager.Domain.Interfaces;

namespace GymManager.Infrastructure.FileAdapter;

/* This adapter class takes C#'s StreamReader file reader and implements
 * the GymManager's generic IFileReaderAdapter<T> interface to manage our file I/O logic.
 * It takes raw string inputs from text files and creates objects for the repository.
 * 
 * The Func<string, T> mapLineToObject parameter allows the adapter to remain generic,
 * taking in the logic of any specific string format to create any specific object for
 * whatever repository. For our purposes, this class will be used for Members and Equipments.
 *
 * As an example, this class can be used for Member objects by including this snippet:
 *
 
var adapter = new FileAdapter<Member>(
    "members.txt",
    Member.FromCsv,   // mapping from line → Member
    member => member.ToCsv() // mapping from Member → line
);

 */

public class FileAdapter<T>
{
    private readonly string _filePath;
    private readonly Func<string, T> _mapLineToObject;
    private readonly Func<T, string> _mapObjectToLine;

    public FileAdapter(
        string filePath,
        Func<string, T> mapLineToObject,
        Func<T, string> mapObjectToLine)
    {
        _filePath = filePath;
        _mapLineToObject = mapLineToObject;
        _mapObjectToLine = mapObjectToLine;
    }

    public void ReadIntoRepository(IRepository<T> repository)
    {
        repository.Clear();
        foreach (var line in File.ReadLines(_filePath))
        {
            var obj = _mapLineToObject(line);
            repository.Add(obj);
        }
    }

    public void WriteFromRepository(IRepository<T> repository)
    {
        using var writer = new StreamWriter(_filePath);
        foreach (var item in repository.GetAll())
        {
            writer.WriteLine(_mapObjectToLine(item));
        }
    }
}