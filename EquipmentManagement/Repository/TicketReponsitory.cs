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

        public void UpdateTicket(int userId, int equipmentId, Ticket ticket)
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
    }
}
