using GymManager.Domain.Models;
using GymManager.Domain.Interfaces;
using GymManager.Infrastructure.FileAdapter;
using GymManager.Infrastructure.Repositories;
using GymManager.Application.Menus;

namespace GymManager.Application
{
    public class GymApp
    {
        private readonly EquipmentRepo _equipmentRepo;
        private readonly MemberRepo _memberRepo;
        private readonly UserRepo _userRepo;
        private readonly FileAdapter<Equipment> _equipmentAdapter;
        private readonly FileAdapter<Member> _memberAdapter;

        private IMenuStrategy? _menu;

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

        public void Run()
        {
            Console.WriteLine("=== LOGIN ===");

            Console.Write("User ID: ");
            int id = int.Parse(Console.ReadLine() ?? "0");

            Console.Write("Password: ");
            string password = Console.ReadLine() ?? "";

            GymUser? user = _userRepo.Authenticate(id, password);
            if (user == null)
            {
                Console.WriteLine("Login failed.");
                return;
            }

            Console.WriteLine($"Welcome, {user.Role}!");

            _menu = MenuFactory.GetMenu(user, this);

            bool exit = false;
            while (!exit)
            {
                _menu.ShowMenu();
                Console.Write("Select option: ");
                string? choice = Console.ReadLine();
                exit = !_menu.HandleChoice(choice ?? "");
            }
        }

        // ================= REAL APP METHODS =================

        public bool ListEquipment()
        {
            foreach (var eq in _equipmentRepo.GetAll())
                Console.WriteLine(eq);
            return true;
        }

        public bool ListMembers()
        {
            foreach (var m in _memberRepo.GetAll())
                Console.WriteLine(m);
            return true;
        }

        public bool ListDirtyEquipment()
        {
            foreach (var eq in _equipmentRepo.FindNeedingCleaning(DateTime.Now))
                Console.WriteLine(eq);
            return true;
        }

        public bool CleanEquipment()
        {
            Console.Write("Equipment ID: ");
            int id = int.Parse(Console.ReadLine() ?? "0");

            var eq = _equipmentRepo.FindById(id);
            if (eq == null) return true;

            eq.Clean();
            _equipmentRepo.Update(eq);
            Console.WriteLine("Equipment cleaned.");
            return true;
        }

        public bool MaintainEquipment()
        {
            Console.Write("Equipment ID: ");
            int id = int.Parse(Console.ReadLine() ?? "0");

            var eq = _equipmentRepo.FindById(id);
            if (eq == null) return true;

            eq.Maintain();
            _equipmentRepo.Update(eq);
            Console.WriteLine("Equipment maintained.");
            return true;
        }

        public bool AddMember()
        {
            Console.Write("Member ID: ");
            int id = int.Parse(Console.ReadLine() ?? "0");

            Console.Write("Member Name: ");
            string name = Console.ReadLine() ?? "Unknown";

            _memberRepo.Add(new Member(id, name, DateTime.Now));
            Console.WriteLine("Member added.");
            return true;
        }

        public bool AddEquipment()
        {
            Console.Write("Equipment ID: ");
            int id = int.Parse(Console.ReadLine() ?? "0");

            Console.Write("Name: ");
            string name = Console.ReadLine() ?? "Unknown";

            var cleaning = new Schedule(DateTime.Now, DateTime.Now.AddDays(7));
            var maintenance = new Schedule(DateTime.Now, DateTime.Now.AddDays(30));

            _equipmentRepo.Add(new Equipment(id, EQType.Misc, name, cleaning, maintenance));
            Console.WriteLine("Equipment added.");
            return true;
        }

        public bool SaveAll()
        {
            _equipmentAdapter.WriteFromRepository(_equipmentRepo);
            _memberAdapter.WriteFromRepository(_memberRepo);
            Console.WriteLine("Saved.");
            return true;
        }
        public bool RemoveEquipment()
        {
            Console.Write("Enter Equipment ID to remove: ");
            int id = int.Parse(Console.ReadLine() ?? "0");

            var eq = _equipmentRepo.FindById(id);
            if (eq == null)
            {
                Console.WriteLine("Equipment not found.");
                return true;
            }

            _equipmentRepo.Remove(eq);
            Console.WriteLine("Equipment removed.");
            return true;
        }

        public bool AddUser()
        {
            Console.Write("User ID: ");
            int id = int.Parse(Console.ReadLine() ?? "0");

            Console.Write("Password: ");
            string password = Console.ReadLine() ?? "";

            Console.Write("Role (admin/owner/employee): ");
            string role = (Console.ReadLine() ?? "employee").ToLower();

            GymUser user = role.ToLower() switch
            {
                "admin" => new AdminUser(id, password),
                "owner" => new OwnerUser(id, password),
                _ => new EmployeeUser(id, password)
            };

            _userRepo.Add(user);
            Console.WriteLine("User added.");
            return true;
        }

        public bool RemoveUser()
        {
            Console.Write("Enter User ID to remove: ");
            int id = int.Parse(Console.ReadLine() ?? "0");

            var user = _userRepo.FindById(id);
            if (user == null)
            {
                Console.WriteLine("User not found.");
                return true;
            }

            _userRepo.Remove(user);
            Console.WriteLine("User removed.");
            return true;
        }
        
        public bool RemoveMember()
        {
            Console.Write("Enter Member ID to remove: ");
            int id = int.Parse(Console.ReadLine() ?? "0");

            var member = _memberRepo.FindById(id);
            if (member == null)
            {
                Console.WriteLine("Member not found.");
                return true;
            }

            _memberRepo.Remove(member);
            Console.WriteLine("Member removed.");
            return true;
        }


    }
}
