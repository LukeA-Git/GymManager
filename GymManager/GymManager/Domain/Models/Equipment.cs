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

    public static Equipment FromCsvLine(string line)
    {
        var parts = line.Split(',');

        return new Equipment(
            int.Parse(parts[0].Trim()),
            Enum.Parse<EQType>(parts[1].Trim()),
            parts[2].Trim(),
            new Schedule(
                DateTime.Parse(parts[3].Trim()),
                DateTime.Parse(parts[4].Trim())
            ),
            new Schedule(
                DateTime.Parse(parts[5].Trim()),
                DateTime.Parse(parts[6].Trim())
            )
        );
    }
}