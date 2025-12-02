using GymManager.Domain.Models;

namespace GymManager.Domain.Models
{
    public class OwnerUser : GymUser
    {
        public OwnerUser()
        {
            Role = "Owner";

            // FULL ACCESS
            CanAdjustPerm = true;
            CanReqAudit = true;
            CanRequest = true;
        }
    }
}