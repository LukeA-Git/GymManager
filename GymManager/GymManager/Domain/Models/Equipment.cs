using System;
using GymManager.Domain.Models;

public class Equipment
{
    public int Id { get; }
    public EQType EQType { get; }
    public string Name { get; }
    public Schedule Cleaning { get; private set; }
    public Schedule Maintenance { get; private set; }

    public Equipment(int id, EQType type, string name, Schedule cleaning, Schedule maintenance)
    {
        Id = id;
        EQType = type;
        Name = name;
        Cleaning = cleaning;
        Maintenance = maintenance;
    }

    public void Clean()
    {
        Cleaning.LastPerformed = DateTime.Now;
    }

    public void Maintain()
    {
        Maintenance.LastPerformed = DateTime.Now;
    }

    public bool IsDueForCleaning(DateTime currentDate)
    {
        return currentDate >= Cleaning.NextScheduled;
    }

    public bool IsDueForMaintenance(DateTime currentDate)
    {
        return currentDate >= Maintenance.NextScheduled;
    }

    public string ToCsvLine()
    {
        return $"{Id},{EQType},{Name},{Cleaning.NextScheduled:yyyy-MM-dd},{Maintenance.NextScheduled:yyyy-MM-dd}";
    }

    public override string ToString()
    {
        return $"Equipment ID: {Id}, Name: {Name}, Type: {EQType}, " +
               $"Last Cleaning: {Cleaning.LastPerformed:yyyy-MM-dd} " +
               $"Last Maintenance: {Maintenance.LastPerformed:yyyy-MM-dd}";
    }

    public static Equipment FromCsvLine(string line)
    {
        var parts = line.Split(',');

        int id = int.Parse(parts[0].Trim());
        EQType type = Enum.Parse<EQType>(parts[1].Trim());
        string name = parts[2].Trim();

        DateTime cleanLast = DateTime.Parse(parts[3].Trim());
        DateTime cleanNext = DateTime.Parse(parts[4].Trim());

        DateTime maintainLast = parts.Length > 5
            ? DateTime.Parse(parts[5].Trim())
            : cleanLast;

        DateTime maintainNext = parts.Length > 6
            ? DateTime.Parse(parts[6].Trim())
            : cleanNext.AddDays(30);

        return new Equipment(
            id,
            type,
            name,
            new Schedule(cleanLast, cleanNext),
            new Schedule(maintainLast, maintainNext)
        );
    }

}