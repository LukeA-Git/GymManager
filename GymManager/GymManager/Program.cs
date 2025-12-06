using System;
using GymManager.Application;
using GymManager.Domain.Models;
using GymManager.Infrastructure.FileAdapter;
using GymManager.Infrastructure.Repositories;

namespace GymManager;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter path to equipment data file:");
        string equipmentFile = Console.ReadLine() ?? "";

        Console.WriteLine("Enter path to member data file:");
        string memberFile = Console.ReadLine() ?? "";

        Console.WriteLine("Enter path to user data file:");
        string userFile = Console.ReadLine() ?? "";

        var equipmentRepo = new EquipmentRepo();
        var memberRepo = new MemberRepo();
        var userRepo = new UserRepo();

        var equipmentAdapter = new FileAdapter<Equipment>(
            equipmentFile,
            Equipment.FromCsvLine,
            eq => eq.ToCsvLine()
        );

        var memberAdapter = new FileAdapter<Member>(
            memberFile,
            Member.FromCsvLine,
            m => m.ToCsvLine()
        );

        var userAdapter = new FileAdapter<GymUser>(
            userFile,
            UserFactory.FromCsvLine,
            u => u.ToCsvLine()
        );

        equipmentAdapter.ReadIntoRepository(equipmentRepo);
        memberAdapter.ReadIntoRepository(memberRepo);
        userAdapter.ReadIntoRepository(userRepo);

        var app = new GymApp(
            equipmentRepo,
            memberRepo,
            userRepo,
            equipmentAdapter,
            memberAdapter
        );

        app.Run();

        // ✅ AUTO-SAVE USERS ON EXIT
        userAdapter.WriteFromRepository(userRepo);
    }
}