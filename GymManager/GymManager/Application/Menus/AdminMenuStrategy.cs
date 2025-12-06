using System;
using GymManager.Domain.Interfaces;

namespace GymManager.Application.Menus
{
    public class AdminMenuStrategy : IMenuStrategy
    {
        public void ShowMenu()
        {
            Console.WriteLine("\n--- ADMIN MENU ---");
            Console.WriteLine("1. Add Employee");
            Console.WriteLine("2. Remove Employee");
            Console.WriteLine("3. View All Users");
            Console.WriteLine("4. Logout");
        }
    }
}