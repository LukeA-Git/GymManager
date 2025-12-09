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
            Console.WriteLine("4. View Equipment Needing Maintenance");
            Console.WriteLine("5. Clean Equipment");
            Console.WriteLine("6. Maintain Equipment");
            Console.WriteLine("7. Add Equipment");
            Console.WriteLine("8. Remove Equipment");
            Console.WriteLine("9. Add Member");
            Console.WriteLine("10. Remove Member");
            Console.WriteLine("11. Add User");
            Console.WriteLine("12. Remove User");
            Console.WriteLine("13. Save");
            Console.WriteLine("0. Logout");
        }

        public bool HandleChoice(string choice)
        {
            return choice switch
            {
                "1" => _app.ListEquipment(),
                "2" => _app.ListMembers(),
                "3" => _app.ListDirtyEquipment(),
                "4" => _app.ListEquipmentNeedingMaintenance(), 
                "5" => _app.CleanEquipment(),
                "6" => _app.MaintainEquipment(),
                "7" => _app.AddEquipment(),
                "8" => _app.RemoveEquipment(),
                "9" => _app.AddMember(),
                "10" => _app.RemoveMember(),
                "11" => _app.AddUser(),
                "12" => _app.RemoveUser(),
                "13" => _app.SaveAll(),
                "0" => false,
                _ => true
            };
        }
    }
}