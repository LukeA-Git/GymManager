namespace GymManager.Domain.Interfaces
{
    public interface IUser
    {
        int UserID { get; set; }
        string UserPassword { get; set; }

        // READ-ONLY ROLE
        string Role { get; }

        bool CanAdjustPerm { get; }
        bool CanReqAudit { get; }
        bool CanRequest { get; }

        string ToCsvLine();
        bool ValidatePassword(string password);

        void GetAllOpt();
    }
}