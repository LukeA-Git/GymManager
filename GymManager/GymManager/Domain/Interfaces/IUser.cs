using System;

namespace GymManager.Domain.Interfaces
{
    public interface IUser
    {
        int UserID { get; set; }
        string UserPassword { get; set; }
        string Role { get; set; }

        //  in UML: to give user access to options
        string[] GetAllOpt();
    }
}