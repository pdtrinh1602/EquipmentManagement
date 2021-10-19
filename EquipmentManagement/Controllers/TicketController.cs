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

        //Get all
        [HttpGet]  // api/ticket
        public ActionResult<IEnumerable<Ticket>> Get()
        {
            return ticketRepository.GetAllTicket().ToList();
        }

        //Get by id user
        [HttpGet("user/{userId}")]  // api/ticket/id
        public ActionResult<List<Ticket>> GetByUserId(int userId)
        {
            if (ticketRepository.CheckExistUserId(userId))
            {
                return ticketRepository.GetTicketByUserId(userId).ToList();
            }
            return StatusCode(404, "UserId not exist");
        }

        //Get by Id Equipment
        [HttpGet("equipment/{equipmentId}")]  // api/ticket/id
        public ActionResult<List<Ticket>> GetByEquipmentId(int equipmentId)
        {
            if (ticketRepository.CheckExistEquipmentId(equipmentId))
            {
                return ticketRepository.GetTicketByEquipmentId(equipmentId).ToList();
            }
            return StatusCode(404, "EquipmentId not exist");
        }

        //Create
        [HttpPost]  // api/ticket/id
        public ActionResult<List<Ticket>> Post([FromBody] Ticket ticket)
        {
            if (!ticketRepository.CheckExistUserIdInUserTable(ticket.UserId))
            {
                return StatusCode(404, "UserId not exist");
            }
            if (!ticketRepository.CheckExistEquipmentIdInEquipmentTable(ticket.EquipmentId))
            {
                return StatusCode(404, "EquipmentId not exist");
            }
            if (ticketRepository.CheckExistUserIdAndEquipmentId(ticket.UserId, ticket.EquipmentId))
            {
                return StatusCode(400, "EquipmentId and UserId is exists, so not add field");
            }

            ticketRepository.CreateTicket(ticket);
            return new OkObjectResult(ticket);
        }


        [HttpPut]  // api/ticket
        public ActionResult<List<Ticket>> Put([FromBody] Ticket ticket)
        {
            if (ticketRepository.CheckExistUserIdAndEquipmentId(ticket.UserId, ticket.EquipmentId))
            {
                return StatusCode(400, "EquipmentId and UserId is exists, so not update");
            }
            ticketRepository.UpdateTicket(ticket);
            return new OkObjectResult(ticket);
        }

        //[HttpDelete("{id}")]  // api/ticket
        //public ActionResult<List<Ticket>> Delete(int id, [FromBody] Ticket ticket)
        //{
        //    var existsId = context.Tickets.Any(x => x.id == id);
        //    if (!existsId)
        //    {
        //        return NotFound();
        //    }
        //    context.Remove(new Ticket() { id = id });
        //    context.SaveChanges();
        //    return new OkObjectResult(context.Set<Ticket>());
        //}

    }
}
