using GymManager.Domain.Models;
using System.Collections.Generic;

namespace GymManager.Domain.Interfaces
{
    public interface IEquipmentRepo
    {
        List<Equipment> EquipmentList { get; }

        void AddEquipment(Equipment equipment);
        Equipment GetEquipmentByID(int equipmentId);
        void RemoveEquipmentByID(int equipmentId);
    }
}