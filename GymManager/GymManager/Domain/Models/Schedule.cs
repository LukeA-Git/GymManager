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

        // Mark the task as performed now
        public void Perform()
        {
            LastPerformed = DateTime.Now;
        }

        // Check if the task is due
        public bool IsDue(DateTime currentDate)
        {
            return currentDate >= NextScheduled;
        }
    }
}