using GymManager.Domain.Interfaces;

namespace GymManager.Domain.Models
{
    public abstract class GymUser : IUser
    {
        public int UserID { get; set; }
        public string UserPassword { get; set; } = "";

        public abstract string Role { get; }

        public virtual string ToCsvLine()
        {
            return $"{UserID},{UserPassword},{Role}";
        }

        public bool ValidatePassword(string password)
        {
            return UserPassword == password;
        }

        public override string ToString()
        {
            return $"UserID: {UserID}, Role: {Role}";
        }
    }
}