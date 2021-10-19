using Equipment.Models;
using EquipmentManagement.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EquipmentManagement.Controllers
{
    [Route("api/ticket")]
    [ApiController]
    public class TicketController : ControllerBase
    {
        private ITicketReponsitory ticketRepository;

        public TicketController()
        {
            this.ticketRepository = new TicketReponsitory(new EquipmentDBContext());
        }

        [HttpGet]  // api/ticket
        public ActionResult<IEnumerable<Ticket>> Get()
        {
            return ticketRepository.GetAllTicket().ToList();
        }

        [HttpGet("{id}", Name = "getById")]  // api/ticket/id
        public ActionResult<Ticket> Get(int id)
        {
           
        }

        [HttpPost]  // api/ticket/id
        public ActionResult<List<Ticket>> Post(int id, [FromBody] Ticket ticket)
        {
            context.Add(ticket);
            context.SaveChangesAsync();
            return new CreatedAtRouteResult("getById", new { id = ticket.id }, ticket);
        }

        [HttpPut("{id}")]  // api/ticket
        public ActionResult<List<Ticket>> Put(int id, [FromBody] Ticket ticket)
        {
            ticket.id = id;
            context.Entry(ticket).State = EntityState.Modified;
            context.SaveChangesAsync();
            return new OkObjectResult(context.Tickets.FirstOrDefault(x => x.id == id));
        }

        [HttpDelete("{id}")]  // api/ticket
        public ActionResult<List<Ticket>> Delete(int id, [FromBody] Ticket ticket)
        {
            var existsId = context.Tickets.Any(x => x.id == id);
            if (!existsId)
            {
                return NotFound();
            }
            context.Remove(new Ticket() { id = id });
            context.SaveChanges();
            return new OkObjectResult(context.Set<Ticket>());
        }

    }
}
