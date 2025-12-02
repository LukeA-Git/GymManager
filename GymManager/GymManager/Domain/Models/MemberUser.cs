using GymManager.Domain.Models;

namespace GymManager.Domain.Models
{
    public class MemberUser : GymUser
    {
        public MemberUser()
        {
            Role = "Member";

            // Members have NO access to internal system features
            CanAdjustPerm = false;
            CanReqAudit = false;
            CanRequest = false;
        }
    }
}