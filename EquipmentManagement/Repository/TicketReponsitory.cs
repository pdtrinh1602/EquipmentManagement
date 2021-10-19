using Equipment.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EquipmentManagement.Repository
{
    public class TicketReponsitory : ITicketReponsitory
    {
        private EquipmentDBContext context;

        public TicketReponsitory(EquipmentDBContext context)
        {
            this.context = context;
        }

        public IEnumerable<Ticket> GetAllTicket()
        {
            return context.Tickets.AsNoTracking().ToList();
        }

        public IEnumerable<Ticket> GetTicketByEquipmentId(int equipmentId)
        {
            var tickets = context.Tickets.Where(x => x.EquipmentId == equipmentId);
            return tickets;

        }

        public IEnumerable<Ticket> GetTicketByUserId(int userId)
        {
            var tickets = context.Tickets.Where(x => x.UserId == userId);
            return tickets;
        }

        public void UpdateTicket(Ticket ticket)
        {
            ticket.UserId = userId;
            ticket.EquipmentId = equipmentId;
            context.Entry(ticket).State = EntityState.Modified;
            context.SaveChanges();
        }

        public void DeleteTicket(int userId, int equipmentId)
        {

            context.RemoveRange(context.Tickets
                .Where(x => x.EquipmentId == equipmentId && x.UserId == userId));
            context.SaveChanges();
        }

        public void CreateTicket(Ticket ticket)
        {
            context.Add(ticket);
            context.SaveChanges();
        }

        //Check exist id user in tabe User
        public bool CheckExistUserIdInUserTable(int userId)
        {
            return context.Users.Any(x => x.UserId == userId);
        }

        //Check exist id equipment in table Equipment
        public bool CheckExistEquipmentIdInEquipmentTable(int equipmentId)
        {
            return context.Equipment.Any(x => x.EquipmentId == equipmentId);
        }

        public bool CheckExistUserIdAndEquipmentId(int userId, int equipmentId)
        {
            return context.Tickets.Any(x => x.EquipmentId == equipmentId && x.UserId == userId);
        }

        //Check exist id user
        public bool CheckExistUserId(int userId)
        {
            return context.Tickets.Any(x => x.UserId == userId);
        }

        //Check exist id equipment
        public bool CheckExistEquipmentId(int equipmentId)
        {
            return context.Tickets.Any(x => x.EquipmentId == equipmentId);
        }

    }
}
