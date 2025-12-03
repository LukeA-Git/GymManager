using System;

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
        
        public void Perform()
        {
            LastPerformed = DateTime.Now;
        }
        
        public bool IsDue(DateTime currentDate)
        {
            return currentDate >= NextScheduled;
        }
    }
}