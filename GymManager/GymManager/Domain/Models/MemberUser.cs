using GymManager.Domain.Interfaces;

namespace GymManager.Domain.Models
{
    public class MemberUser : GymUser
    {
        public override string Role => "Member";

        public MemberUser(int id, string password)
        {
            UserID = id;
            UserPassword = password;

            CanAdjustPerm = false;
            CanReqAudit = false;
            CanRequest = false;
        }
    }
}