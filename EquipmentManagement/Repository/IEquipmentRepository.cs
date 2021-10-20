using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EquipmentModel = Equipment.Models.Equipment;

namespace EquipmentManagement.Repository
{
    public interface IEquipmentRepository
    {
        IEnumerable<EquipmentModel> GetEquipment();
        EquipmentModel GetEquipmentById(int id);
        List<EquipmentModel> SearchEquipment(string value);
        void CreateEquipmnet(EquipmentModel equipment);
        void DeleteEquipmnet(int id);
        void Save();

    }
}
