using System;
using GymManager.Domain.Interfaces;

namespace GymManager.Application.Menus
{
    public class AdminMenuStrategy : IMenuStrategy
    {
        private readonly GymApp _app;

        public AdminMenuStrategy(GymApp app)
        {
            _app = app;
        }

        public void ShowMenu()
        {
            Console.WriteLine("\n--- ADMIN MENU ---");
            Console.WriteLine("1. View Equipment");
            Console.WriteLine("2. View Members");
            Console.WriteLine("3. View Equipment Needing Cleaning");
            Console.WriteLine("4. Clean Equipment");
            Console.WriteLine("5. Maintain Equipment");
            Console.WriteLine("6. Add Equipment");
            Console.WriteLine("7. Remove Equipment");
            Console.WriteLine("8. Add Member");
            Console.WriteLine("9. Remove Member");
            Console.WriteLine("10. Add User");
            Console.WriteLine("11. Remove User");
            Console.WriteLine("12. Save");
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
                "6" => _app.AddEquipment(),
                "7" => _app.RemoveEquipment(),
                "8" => _app.AddMember(),
                "9" => _app.RemoveMember(),
                "10" => _app.AddUser(),
                "11" => _app.RemoveUser(),
                "12" => _app.SaveAll(),
                "0" => false,
                _ => true
            };
        }
    }
}