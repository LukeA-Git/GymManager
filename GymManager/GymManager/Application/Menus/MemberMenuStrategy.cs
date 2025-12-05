using GymManager.Domain.Interfaces;

namespace GymManager.Application.Menus
{
    public class MemberMenuStrategy : IMenuStrategy
    {
        public void ShowMenu()
        {
            Console.WriteLine("\n--- MEMBER MENU ---");
            Console.WriteLine("1. View workout schedule");
            Console.WriteLine("2. View membership info");
            Console.WriteLine("3. Submit support request");
            Console.WriteLine("4. Logout");
        }
    }
}