using GymManager.Domain.Interfaces;

namespace GymManager.Domain.Models
{
    public class GymUser : IUser
    {
        // From IUser
        public int UserID { get; set; }
        public string UserPassword { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;

        public bool CanAdjustPerm { get; set; }
        public bool CanReqAudit { get; set; }
        public bool CanRequest { get; set; }

        // Returns options this user has
        public string[] GetAllOpt()
        {
            var options = new List<string>();

            if (CanAdjustPerm)
            {
                options.Add("Adjust user permissions");
            }

            if (CanReqAudit)
            {
                options.Add("Request system audit report");
            }

            if (CanRequest)
            {
                options.Add("Submit general request");
            }

            return options.ToArray();
        }
    }
}