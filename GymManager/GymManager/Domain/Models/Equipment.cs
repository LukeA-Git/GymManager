namespace GymManager.Domain.Models
{
    public class Equipment
    {
        public int Id { get; set; }
        public EQType EQType { get; set; }
        public string Name { get; set; }
        public Schedule Cleaning { get; set; }
        public Schedule Maintenance { get; set; }

        public void Clean()
        {
            // TODO: implement the cleaning logic
        }

        public void Maintain()
        {
            // TODO: implement the maintenance logic
        }
    }

    public enum EQType
    {
        Cardio,
        Strength,
        Flexibility,
        Misc
    }
}