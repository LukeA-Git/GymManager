using System;
using GymManager.Domain.Interfaces;
using GymManager.Domain.Models;
using System.Collections.Generic;
using System.Linq;

namespace GymManager.Infrastructure.Repositories
{
    public class EquipmentRepo : IRepository<Equipment>
    {
        private readonly List<Equipment> _equipmentList = new List<Equipment>();

        public void Add(Equipment equipment)
        {
            _equipmentList.Add(equipment);
        }

        public List<Equipment> GetAll()
        {
            return new List<Equipment>(_equipmentList);
        }

        public void Clear()
        {
            _equipmentList.Clear();
        }

        public Equipment FindById(int id)
        {
            return _equipmentList.FirstOrDefault(e => e.Id == id);
        }

        public List<Equipment> FindByType(EQType type)
        {
            return _equipmentList.Where(e => e.EQType == type).ToList();
        }

        public List<Equipment> FindByName(string name)
        {
            return _equipmentList.Where(e => e.Name.Contains(name, StringComparison.OrdinalIgnoreCase)).ToList();
        }

        public void Remove(Equipment equipment)
        {
            _equipmentList.Remove(equipment);
        }

        public void Update(Equipment updatedEquipment)
        {
            var index = _equipmentList.FindIndex(e => e.Id == updatedEquipment.Id);
            if (index >= 0)
            {
                _equipmentList[index] = updatedEquipment;
            }
        }

        public List<Equipment> FindNeedingCleaning(DateTime currentDate)
        {
            return _equipmentList.Where(e => e.IsDueForCleaning(currentDate)).ToList();
        }

        public List<Equipment> FindNeedingMaintenance(DateTime currentDate)
        {
            return _equipmentList.Where(e => e.IsDueForMaintenance(currentDate)).ToList();
        }
    }
}