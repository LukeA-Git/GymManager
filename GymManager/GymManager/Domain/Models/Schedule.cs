namespace GymManager.Domain.Models
{
    public enum ScheduleType
    {
        Cleaning,
        Maintenance
    }

    public class Schedule
    {
        public ScheduleType ScheduleType { get; set; }
        public int DaysUntilNotify { get; set; }

        public void SetDays(int days)
        {
            DaysUntilNotify = days;
        }
    }
}