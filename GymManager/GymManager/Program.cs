using GymManager.Domain.Models;
using GymManager.Infrastructure.Repositories;

namespace GymManager
{
    class Program
    {
        static void Main(string[] args)
        {
            var userRepo = new UserRepo();

            //  DEMO USERS 
            userRepo.Add(new AdminUser
            {
                UserID = 1,
                UserPassword = "admin123",
                Role = "Admin"
            });

            userRepo.Add(new EmployeeUser
            {
                UserID = 10,
                UserPassword = "emp123",
                Role = "Employee"
            });

            userRepo.Add(new MemberUser
            {
                UserID = 100,
                UserPassword = "mem123",
                Role = "Member"
            });

            //  LOGIN LOOP 
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== GYM LOGIN ===");
                Console.Write("Enter User ID: ");
                int id = int.Parse(Console.ReadLine());

                Console.Write("Enter Password: ");
                string password = Console.ReadLine();

                var currentUser = userRepo.Authenticate(id, password);

                if (currentUser == null)
                {
                    Console.WriteLine("\n Invalid login.");
                    Console.WriteLine("Press ENTER to try again...");
                    Console.ReadLine();
                    continue;
                }

                Console.WriteLine($"\n Logged in as: {currentUser.Role} (UserID: {currentUser.UserID})");
                Console.WriteLine("This user has access to:\n");

                foreach (var option in currentUser.GetAllOpt())
                {
                    Console.WriteLine("- " + option);
                }

                Console.WriteLine("\nPress ENTER to logout...");
                Console.ReadLine();
            }
        }
    }
}
