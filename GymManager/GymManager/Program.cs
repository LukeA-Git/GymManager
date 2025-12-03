using System;
using GymManager.Domain.Models;
using GymManager.Infrastructure.FileAdapter;
using GymManager.Infrastructure.Repositories;

namespace GymManager;

class Program
{
    static void Main(string[] args)
    {
        /*
         * Driver function first collect the file paths from the user,
         * creates the empty repository objects
         * then creates File Adapter objects for those files,
         * and lastly calls each adapters' ReadInto method to create
         * and store the respective objects in each repository.
         */
        
        Console.WriteLine("Enter path to equipment data file:");
        string equipmentFile = Console.ReadLine();

        Console.WriteLine("Enter path to member data file:");
        string memberFile = Console.ReadLine();
        
        var equipmentRepo = new EquipmentRepo();
        var memberRepo = new MemberRepo();
        
        var equipmentAdapter = new FileAdapter<Equipment>(
            equipmentFile,
            Equipment.FromCsvLine,
            equipment => equipment.ToCsvLine()
        );

        var memberAdapter = new FileAdapter<Member>(
            memberFile,
            Member.FromCsvLine,
            member => member.ToCsvLine()
        );
        
        equipmentAdapter.ReadIntoRepository(equipmentRepo);
        memberAdapter.ReadIntoRepository(memberRepo);
        
        /*
         * Menu loop that will implement the user access logic
         */
        Console.WriteLine("Welcome to the AGENCY Gym Manager...");
        bool exit = false;
        while (!exit)
        {
            Console.WriteLine("Select an option:");
            Console.WriteLine("1. List all equipment");
            Console.WriteLine("2. List all members");
            Console.WriteLine("3. Find equipment needing cleaning");
            Console.WriteLine("4. Add new member");
            Console.WriteLine("5. Save Changes");
            Console.WriteLine("6. Clean an Equipment");
            Console.WriteLine("7. Maintain an Equipment");
            Console.WriteLine("8. Exit");
            
            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    foreach (Equipment eq in equipmentRepo.GetAll())
                    {
                        Console.WriteLine(eq.ToString());
                    }
                    break;
                case "2":
                    foreach (Member member in memberRepo.GetAll())
                    {
                        Console.WriteLine(member.ToString());
                    }
                    break;
                case "3":
                    List<Equipment> dueEquipment = equipmentRepo.FindNeedingCleaning(DateTime.Now);
                    foreach (Equipment eq in dueEquipment)
                    {
                        Console.WriteLine(eq.ToString());
                    }
                    break;
                case "4":
                    Console.WriteLine("Enter new member ID:");
                    int id = int.Parse(Console.ReadLine());
                    Console.WriteLine("Enter new member name:");
                    string name = Console.ReadLine();
                    Member newMember = new Member(id, name, DateTime.Now);
                    memberRepo.Add(newMember);
                    Console.WriteLine("Member added. Welcome to the Agency...");
                    break;
                case "5":
                    equipmentAdapter.WriteFromRepository(equipmentRepo);
                    memberAdapter.WriteFromRepository(memberRepo);
                    break;
                case "6":
                    Console.WriteLine("Enter equipment ID to clean:");
                    int cleanId = int.Parse(Console.ReadLine());
                    {
                        Equipment eqClean = equipmentRepo.FindById(cleanId);
                        if (eqClean != null)
                        {
                            eqClean.Clean();
                            equipmentRepo.Update(eqClean);
                            Console.WriteLine("Equipment cleaned and schedule updated.");
                        }
                        else
                        {
                            Console.WriteLine("Equipment not found.");
                        }
                    }
                    break;
                case "7":
                    Console.WriteLine("Enter equipment ID to maintain:");
                    int maintainId = int.Parse(Console.ReadLine());
                    Equipment eqMaintain = equipmentRepo.FindById(maintainId);
                    if (eqMaintain != null)
                    {
                        eqMaintain.Maintain();
                        equipmentRepo.Update(eqMaintain);
                        Console.WriteLine("Equipment maintained and schedule updated.");
                    }
                    else
                    {
                        Console.WriteLine("Equipment not found.");
                    }
                    break;
                case "8":
                    Console.WriteLine("Exiting the Agency Gym Manager...");
                    exit = true;
                    break;
                default:
                    Console.WriteLine("Please enter one of the available options...");
                    break;
            }
        }
    }
}