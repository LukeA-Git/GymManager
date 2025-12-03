using System;
using GymManager.Domain.Models;
using GymManager.Infrastructure.Repositories;

namespace GymManager;

class Program
{
    static void Main(string[] args)
    {
        var userRepo = new UserRepo();

        //  DEMO USERS 
        userRepo.AddUser(new AdminUser
        {
            UserID = 1,
            UserPassword = "admin123",
            Role = "Admin"
        });

        userRepo.AddUser(new EmployeeUser
        {
            UserID = 10,
            UserPassword = "emp123",
            Role = "Employee"
        });

        userRepo.AddUser(new MemberUser
        {
            UserID = 100,
            UserPassword = "mem123",
            Role = "Member"
        });

        //  LOGIN PROMPT
        Console.WriteLine("=== GYM LOGIN ===");
        Console.Write("Enter User ID: ");
        int id = int.Parse(Console.ReadLine());

        Console.Write("Enter Password: ");
        string password = Console.ReadLine();

        var currentUser = userRepo.Authenticate(id, password);

        if (currentUser == null)
        {
            Console.WriteLine(" Invalid login.");
            Console.ReadLine();
            return;
        }

        // AFTER LOGIN SHOW PERMISSIONS
        Console.WriteLine($"\n✅ Logged in as: {currentUser.Role} (UserID: {currentUser.UserID})");
        Console.WriteLine("This user has access to:");

        foreach (var option in currentUser.GetAllOpt())
        {
            Console.WriteLine("- " + option);
        }

        Console.WriteLine("\nPress ENTER to exit...");
        Console.ReadLine();
    }
}