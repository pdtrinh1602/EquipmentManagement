using Equipment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EquipmentModel = Equipment.Models.Equipment;

namespace EquipmentManagement.Repository
{
    public class EquipmentRepository : IEquipmentRepository
    {
        public EquipmentDBContext context;

        public EquipmentRepository(EquipmentDBContext context)
        {
            this.context = context;
        }

        public IEnumerable<EquipmentModel> GetEquipment()
        {
            return context.Equipment.ToList();
        }

        public EquipmentModel GetEquipmentById(int id)
        {
            return context.Equipment.Find(id);
        }

        public List<EquipmentModel> SearchEquipment(string value)
        {
            List<EquipmentModel> equipment = context.Equipment.Where(x => x.EquipmentName.Contains(value) || x.Type.Contains(value)).ToList();
            return equipment;
        }

        public void CreateEquipmnet(EquipmentModel equipment)
        {
            context.Equipment.Add(equipment);
            context.SaveChanges();
        }

        public void DeleteEquipmnet(int id)
        {
            EquipmentModel equipment = context.Equipment.Where(x => x.EquipmentId == id && x.IsAvailable == true).FirstOrDefault();
            context.Equipment.Remove(equipment);
            context.SaveChanges();
        }

        public void UpdateEquipmnet(int id)
        {
            EquipmentModel equipment = context.Equipment.Find(id);
            context.Equipment.Remove(equipment);
            context.SaveChanges();
        }

        public void Save()
        {
            context.SaveChanges();
        }

    }
}
