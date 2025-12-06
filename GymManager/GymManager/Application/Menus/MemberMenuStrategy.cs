using System;
using GymManager.Domain.Interfaces;

namespace GymManager.Application.Menus
{
    public class MemberMenuStrategy : IMenuStrategy
    {
        public void ShowMenu()
        {
            Console.WriteLine("\n--- MEMBER MENU ---");
            Console.WriteLine("1. View personal info");
            Console.WriteLine("2. View equipment");
            Console.WriteLine("0. Logout");
        }

        public bool HandleChoice(string choice)
        {
            switch (choice)
            {
                case "1":
                    Console.WriteLine("Member profile feature coming soon...");
                    return true;

                case "2":
                    Console.WriteLine("Viewing equipment (read-only)...");
                    return true;

                case "0":
                    return false;

                default:
                    Console.WriteLine("Invalid option.");
                    return true;
            }
        }
    }
}