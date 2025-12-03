using System;
using GymManager.Domain.Models;

namespace GymManager;

class Program
{
    static void Main(string[] args)
    {
        // You can switch to see other user perms
        GymUser currentUser = new EmployeeUser();
        // or new AdminUser();
        // or new MemberUser();
        // or new OwnerUser();

        Console.WriteLine($"Logged in as: {currentUser.Role} (UserID: {currentUser.UserID})");
        Console.WriteLine("This user has access to:");

        foreach (var option in currentUser.GetAllOpt())
        {
            Console.WriteLine("- " + option);
        }

        Console.WriteLine("\nPress ENTER to exit...");
        Console.ReadLine();
    }
    
}