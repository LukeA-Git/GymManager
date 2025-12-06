using System;
using GymManager.Domain.Interfaces;

namespace GymManager.Application.Menus
{
    public class OwnerMenuStrategy : IMenuStrategy
    {
        public void ShowMenu()
        {
            Console.WriteLine("\n--- OWNER MENU ---");
            Console.WriteLine("1. View financial reports");
            Console.WriteLine("2. Manage admins");
            Console.WriteLine("3. View gym performance");
            Console.WriteLine("4. Logout");
        }
    }
}