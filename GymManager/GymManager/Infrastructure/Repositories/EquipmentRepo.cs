using GymManager.Domain.Interfaces;
using GymManager.Domain.Models;
using System.Collections.Generic;
using System.Linq;

namespace GymManager.Infrastructure.Repositories
{
    public class EquipmentRepo : IEquipmentRepo
    {
        public List<Equipment> EquipmentList { get; } = new();

        public void AddEquipment(Equipment equipment)
        {
            EquipmentList.Add(equipment);
        }

        public Equipment GetEquipmentByID(int equipmentId)
        {
            return EquipmentList.FirstOrDefault(e => e.Id == equipmentId);
        }

        public void RemoveEquipmentByID(int equipmentId)
        {
            var eq = GetEquipmentByID(equipmentId);
            if (eq != null)
                EquipmentList.Remove(eq);
        }
    }
}