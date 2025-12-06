namespace GymManager.Domain.Models
{
    public class Schedule
    {
        public DateTime LastPerformed { get; set; }
        public DateTime NextScheduled { get; set; }

        public Schedule(DateTime lastPerformed, DateTime nextScheduled)
        {
            LastPerformed = lastPerformed;
            NextScheduled = nextScheduled;
        }

        public bool IsDue()
        {
            return DateTime.Now >= NextScheduled;
        }

        public void UpdateNext(int days)
        {
            LastPerformed = DateTime.Now;
            NextScheduled = DateTime.Now.AddDays(days);
        }
    }
}