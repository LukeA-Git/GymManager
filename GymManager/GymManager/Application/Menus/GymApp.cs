using GymManager.Domain.Models;
using GymManager.Domain.Interfaces;
using GymManager.Infrastructure.FileAdapter;
using GymManager.Infrastructure.Repositories;

namespace GymManager.Application
{
    public class GymApp
    {
        private readonly EquipmentRepo _equipmentRepo;
        private readonly MemberRepo _memberRepo;
        private readonly UserRepo _userRepo;
        private readonly FileAdapter<Equipment> _equipmentAdapter;
        private readonly FileAdapter<Member> _memberAdapter;

        public GymApp(
            EquipmentRepo equipmentRepo,
            MemberRepo memberRepo,
            UserRepo userRepo,
            FileAdapter<Equipment> equipmentAdapter,
            FileAdapter<Member> memberAdapter)
        {
            _equipmentRepo = equipmentRepo;
            _memberRepo = memberRepo;
            _userRepo = userRepo;
            _equipmentAdapter = equipmentAdapter;
            _memberAdapter = memberAdapter;
        }

        
        // MAIN APP LOOP
        
        public void Run()
        {
            Console.WriteLine("=== LOGIN ===");

            Console.Write("User ID: ");
            int id = int.Parse(Console.ReadLine() ?? "0");

            Console.Write("Password: ");
            string password = Console.ReadLine() ?? "";

            IUser? user = _userRepo.Authenticate(id, password);

            if (user == null)
            {
                Console.WriteLine("Login failed.");
                return;
            }

            Console.WriteLine($"Welcome, {user.Role}!");

            bool exit = false;
            while (!exit)
            {
                ShowMenu(user);
                string? choice = Console.ReadLine();
                exit = !HandleChoice(choice, user);
            }
        }

        
        // MENU DISPLAY
        
        private void ShowMenu(IUser user)
        {
            Console.WriteLine();
            Console.WriteLine("1. List all equipment");
            Console.WriteLine("2. List all members");
            Console.WriteLine("3. Find equipment needing cleaning");
            Console.WriteLine("4. Add new member");
            Console.WriteLine("5. Save changes");
            Console.WriteLine("6. Clean equipment");
            Console.WriteLine("7. Maintain equipment");

            if (CanAddEquipment(user))
                Console.WriteLine("8. Add new equipment");

            if (IsAdmin(user))
                Console.WriteLine("9. Add new user");

            Console.WriteLine("0. Exit");
        }

        
        // MENU HANDLER
        
        private bool HandleChoice(string? choice, IUser user)
        {
            switch (choice)
            {
                case "1":
                    foreach (var eq in _equipmentRepo.GetAll())
                        Console.WriteLine(eq);
                    return true;

                case "2":
                    foreach (var m in _memberRepo.GetAll())
                        Console.WriteLine(m);
                    return true;

                case "3":
                    foreach (var eq in _equipmentRepo.FindNeedingCleaning(DateTime.Now))
                        Console.WriteLine(eq);
                    return true;

                case "4":
                    AddMember();
                    return true;

                case "5":
                    _equipmentAdapter.WriteFromRepository(_equipmentRepo);
                    _memberAdapter.WriteFromRepository(_memberRepo);
                    Console.WriteLine("Changes saved.");
                    return true;

                case "6":
                    CleanEquipment();
                    return true;

                case "7":
                    MaintainEquipment();
                    return true;

                case "8":
                    if (CanAddEquipment(user))
                        AddEquipment();
                    else
                        Console.WriteLine("Permission denied.");
                    return true;

                case "9":
                    if (IsAdmin(user))
                        AddUser();
                    else
                        Console.WriteLine("Admins only.");
                    return true;

                case "0":
                    Console.WriteLine("Exiting...");
                    return false;

                default:
                    Console.WriteLine("Invalid option.");
                    return true;
            }
        }

        
        // ROLE CHECKS
        
        private static bool IsAdmin(IUser user) =>
            user.Role.Equals("Admin", StringComparison.OrdinalIgnoreCase);

        private static bool CanAddEquipment(IUser user) =>
            user.Role.Equals("Admin", StringComparison.OrdinalIgnoreCase) ||
            user.Role.Equals("Owner", StringComparison.OrdinalIgnoreCase);

        
        // ACTION METHODS
        
        private void AddMember()
        {
            Console.Write("Member ID: ");
            int id = int.Parse(Console.ReadLine() ?? "0");

            Console.Write("Member Name: ");
            string name = Console.ReadLine() ?? "Unknown";

            var member = new Member(id, name, DateTime.Now);
            _memberRepo.Add(member);
            Console.WriteLine("Member added.");
        }

        private void CleanEquipment()
        {
            Console.Write("Equipment ID: ");
            int id = int.Parse(Console.ReadLine() ?? "0");

            var eq = _equipmentRepo.FindById(id);
            if (eq == null)
            {
                Console.WriteLine("Not found.");
                return;
            }

            eq.Clean();
            _equipmentRepo.Update(eq);
            Console.WriteLine("Equipment cleaned.");
        }

        private void MaintainEquipment()
        {
            Console.Write("Equipment ID: ");
            int id = int.Parse(Console.ReadLine() ?? "0");

            var eq = _equipmentRepo.FindById(id);
            if (eq == null)
            {
                Console.WriteLine("Not found.");
                return;
            }

            eq.Maintain();
            _equipmentRepo.Update(eq);
            Console.WriteLine("Equipment maintained.");
        }

        private void AddEquipment()
        {
            Console.Write("Equipment ID: ");
            int id = int.Parse(Console.ReadLine() ?? "0");

            Console.Write("Name: ");
            string name = Console.ReadLine() ?? "Unknown";

            Console.Write("Type (Cardio/Strength/Flexibility/Misc): ");
            var type = Enum.Parse<EQType>(Console.ReadLine() ?? "Misc", true);

            var cleaning = new Schedule(DateTime.Now, DateTime.Now.AddDays(7));
            var maintenance = new Schedule(DateTime.Now, DateTime.Now.AddDays(30));

            var eq = new Equipment(id, type, name, cleaning, maintenance);
            _equipmentRepo.Add(eq);

            Console.WriteLine("Equipment added.");
        }

        // MATCH USER CLASSES
        private void AddUser()
        {
            Console.Write("User ID: ");
            int id = int.Parse(Console.ReadLine() ?? "0");

            Console.Write("Password: ");
            string password = Console.ReadLine() ?? "";

            Console.Write("Role (Admin/Owner/Employee): ");
            string role = Console.ReadLine() ?? "Employee";

            GymUser user = role.ToLower() switch
            {
                "admin" => new AdminUser(id, password),
                "owner" => new OwnerUser(id, password),
                _ => new EmployeeUser(id, password)
            };

            _userRepo.Add(user);
            Console.WriteLine("User created.");
        }

    }
}
