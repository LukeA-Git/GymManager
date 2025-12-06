using GymManager.Domain.Interfaces;
using System;

namespace GymManager.Domain.Models
{
    public abstract class GymUser : IUser
    {
        public int UserID { get; set; }
        public string UserPassword { get; set; } = "";

        public abstract string Role { get; }

        public bool CanAdjustPerm { get; protected set; }
        public bool CanReqAudit { get; protected set; }
        public bool CanRequest { get; protected set; }

        public virtual string ToCsvLine()
        {
            return $"{UserID},{UserPassword},{Role}";
        }

        public bool ValidatePassword(string password)
        {
            return UserPassword == password;
        }

        public virtual void GetAllOpt()
        {
            Console.WriteLine("Base User Options");
        }

        public override string ToString()
        {
            return $"UserID: {UserID}, Role: {Role}";
        }
    }
}