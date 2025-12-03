using GymManager.Domain.Interfaces;

namespace GymManager.Infrastructure.FileReaders;

/* This adapter class takes C#'s StreamReader file reader and implements
 * the GymManager's generic IFileReaderAdapter<T> interface to manage our file I/O logic.
 * It takes raw string inputs from text files and creates objects for the repository.
 * 
 * The Func<string, T> mapLineToObjectFunc parameter allows the adapter to remain generic,
 * taking in the logic of any specific string format to create any specific object for
 * whatever repository. For our purposes, this class will be used for Members and Equipments.
 */

public class FileReaderAdapter<T> : IFileReaderAdapter<T>
{
    private readonly string _filePath;
    private readonly Func<string, T> _mapLineToObjectFunc;

    public FileReaderAdapter(string filePath, Func<string, T> mapLineToObjectFunc)
    {
        _filePath = filePath;
        _mapLineToObjectFunc = mapLineToObjectFunc;
    }

    public void ReadIntoRepository(IRepository<T> repository)
    {
        using (var reader = new StreamReader(_filePath))
        {
            string? line;
            while ((line = reader.ReadLine()) != null)
            {
                T obj = _mapLineToObjectFunc(line);
                repository.Add(obj);
            }
        }
    }
}