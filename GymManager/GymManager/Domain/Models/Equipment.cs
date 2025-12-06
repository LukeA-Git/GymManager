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
        Cleaning.UpdateNext(7);   // every 7 days
    }

    public void Maintain()
    {
        Maintenance.UpdateNext(30); // every 30 days
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
        return $"{Id},{EQType},{Name}," +
               $"{Cleaning.LastPerformed:yyyy-MM-dd}," +
               $"{Cleaning.NextScheduled:yyyy-MM-dd}," +
               $"{Maintenance.LastPerformed:yyyy-MM-dd}," +
               $"{Maintenance.NextScheduled:yyyy-MM-dd}";
    }

    public override string ToString()
    {
        return
            $"Equipment ID: {Id}, Name: {Name}, Type: {EQType}\n" +
            $"  Last Cleaning: {Cleaning.LastPerformed:yyyy-MM-dd}\n" +
            $"  Next Cleaning: {Cleaning.NextScheduled:yyyy-MM-dd}\n" +
            $"  Last Maintenance: {Maintenance.LastPerformed:yyyy-MM-dd}\n" +
            $"  Next Maintenance: {Maintenance.NextScheduled:yyyy-MM-dd}";
    }

    public static Equipment FromCsvLine(string line)
    {
        var parts = line.Split(',');

        int id = int.Parse(parts[0].Trim());
        EQType type = Enum.Parse<EQType>(parts[1].Trim());
        string name = parts[2].Trim();
        

        DateTime cleanLast = DateTime.Parse(parts[3].Trim());
        DateTime cleanNext2 = DateTime.Parse(parts[4].Trim());
        DateTime maintainLast = DateTime.Parse(parts[5].Trim());
        DateTime maintainNext2 = DateTime.Parse(parts[6].Trim());

        return new Equipment(
            id,
            type,
            name,
            new Schedule(cleanLast, cleanNext2),
            new Schedule(maintainLast, maintainNext2)
        );
    }

}
