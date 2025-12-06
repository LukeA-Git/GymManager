using System;
using GymManager.Domain.Interfaces;

namespace GymManager.Application.Menus
{
    public class EmployeeMenuStrategy : IMenuStrategy
    {
        public void ShowMenu()
        {
            Console.WriteLine("\n--- EMPLOYEE MENU ---");
            Console.WriteLine("1. Check in member");
            Console.WriteLine("2. View equipment");
            Console.WriteLine("3. Submit maintenance request");
            Console.WriteLine("4. Logout");
        }
    }
}