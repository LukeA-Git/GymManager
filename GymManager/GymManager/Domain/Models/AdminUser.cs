namespace GymManager.Domain.Models
{
    public class AdminUser : GymUser
    {
        public override string Role => "Admin";

        public AdminUser(int id, string password)
        {
            UserID = id;
            UserPassword = password;

            CanAdjustPerm = true;
            CanReqAudit = true;
            CanRequest = true;
        }
    }
}