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
            Console.WriteLine("1. List Equipment");
            Console.WriteLine("2. List Members");
            Console.WriteLine("3. View Equipment Needing Cleaning");
            Console.WriteLine("4. View Equipment Needing Maintenance");  
            Console.WriteLine("5. Clean Equipment");
            Console.WriteLine("6. Maintain Equipment");
            Console.WriteLine("7. Save");
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
                "7" => _app.SaveAll(),
                "0" => false,
                _ => true
            };
        }
    }
}