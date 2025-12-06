namespace GymManager.Domain.Models
{
    public class OwnerUser : GymUser
    {
        public override string Role => "Owner";

        public OwnerUser(int id, string password)
        {
            UserID = id;
            UserPassword = password;

            CanAdjustPerm = true;
            CanReqAudit = true;
            CanRequest = true;
        }
    }
}