using System;
using GymManager.Domain.Interfaces;
using GymManager.Domain.Models;
using GymManager.Infrastructure.Repositories;
using GymManager.Application.Menus;

namespace GymManager;

class Program
{
    static void Main(string[] args)
    {
        // CREATE USER REPOSITORY
        var userRepo = new UserRepo();

        // SEED USERS (Admin, Owner, Employee, Member)
        userRepo.Add(new AdminUser { UserID = 1, UserPassword = "admin", Role = "Admin" });
        userRepo.Add(new OwnerUser { UserID = 2, UserPassword = "own", Role = "Owner" });
        userRepo.Add(new EmployeeUser { UserID = 3, UserPassword = "emp", Role = "Employee" });

        // LOGIN
        Console.WriteLine("=== LOGIN ===");
        Console.Write("User ID: ");
        int id = int.Parse(Console.ReadLine()!);

        Console.Write("Password: ");
        string password = Console.ReadLine()!;

        IUser? user = userRepo.Authenticate(id, password);

        if (user == null)
        {
            Console.WriteLine(" Login failed.");
            return;
        }

        Console.WriteLine($"\n Logged in as {user.Role}");

        // STRATEGY MENU SELECTION
        IMenuStrategy menu = user switch
        {
            AdminUser => new AdminMenuStrategy(),
            OwnerUser => new OwnerMenuStrategy(),
            EmployeeUser => new EmployeeMenuStrategy(),
            _ => throw new Exception("Unknown user role")
        };

        // SHOW MENU
        menu.ShowMenu();

        Console.WriteLine("\nPress ENTER to exit...");
        Console.ReadLine();
    }
}
