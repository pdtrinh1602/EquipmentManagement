using Equipment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EquipmentManagement.Repository
{
    public interface ITicketReponsitory
    {
        //Get all
        IEnumerable<Ticket> GetAllTicket();

        //Get by user id
        IEnumerable<Ticket> GetTicketByUserId(int userId);

        //Get by Equipment id
        IEnumerable<Ticket> GetTicketByEquipmentId(int equipmentId);

        //Update Equipment
        void UpdateTicket(Ticket ticket);

        //Delete Ticket
        void DeleteTicket(int userId, int equipmentId);

        //Create ticket
        void CreateTicket(Ticket ticket);

        //Check exist id user in table User
        bool CheckExistUserIdInUserTable(int userId);

        //Check exist id equipment in table Equipment
        bool CheckExistEquipmentIdInEquipmentTable(int equipmentId);

        //Check exist id user and id equipment
        bool CheckExistUserIdAndEquipmentId(int userId, int equipmentId);

        //Check exist id user in table User
        bool CheckExistUserId(int userId);

        //Check exist id equipment in table Equipment
        bool CheckExistEquipmentId(int equipmentId);
    }
}
