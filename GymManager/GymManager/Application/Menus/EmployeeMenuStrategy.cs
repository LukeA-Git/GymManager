using System;
using GymManager.Domain.Interfaces;

namespace GymManager.Application.Menus
{
    public class EmployeeMenuStrategy : IMenuStrategy
    {
        private readonly GymApp _app;

        public EmployeeMenuStrategy(GymApp app)
        {
            _app = app;
        }

        public void ShowMenu()
        {
            Console.WriteLine("\n--- EMPLOYEE MENU ---");
            Console.WriteLine("1. List equipment");
            Console.WriteLine("2. List members");
            Console.WriteLine("3. View dirty equipment");
            Console.WriteLine("4. Clean equipment");
            Console.WriteLine("5. Maintain equipment");
            Console.WriteLine("6. Save");
            Console.WriteLine("0. Logout");
        }

        public bool HandleChoice(string choice)
        {
            return choice switch
            {
                "1" => _app.ListEquipment(),
                "2" => _app.ListMembers(),
                "3" => _app.ListDirtyEquipment(),
                "4" => _app.CleanEquipment(),
                "5" => _app.MaintainEquipment(),
                "6" => _app.SaveAll(),
                "0" => false,
                _ => true
            };
        }
    }
}