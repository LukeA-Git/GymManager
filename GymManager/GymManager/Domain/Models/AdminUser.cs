using GymManager.Domain.Models;

namespace GymManager.Domain.Models
{
    public class AdminUser : GymUser
    {
        public AdminUser()
        {
            Role = "Admin";

            // Admin can run audits and general requests
            CanAdjustPerm = false;
            CanReqAudit = true;
            CanRequest = true;
        }
    }
}