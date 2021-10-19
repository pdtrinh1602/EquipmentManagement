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
        void UpdateTicket(int userId, int equipmentId, Ticket ticket);

        //Delete Ticket
        void DeleteTicket(int userId, int equipmentId);

    }
}
