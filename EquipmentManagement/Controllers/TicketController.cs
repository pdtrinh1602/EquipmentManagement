using Equipment.Models;
using EquipmentManagement.DTOs.Ticket;
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

        //Get by UserId and EquipmentId
        [HttpPost("user-and-equipment")]  // api/ticket
        public ActionResult<List<Ticket>> GetByUserAndEquipment([FromBody] MultiIdDto multiIdDto)
        {
            if (!ticketRepository.CheckExistUserIdAndEquipmentId(multiIdDto.userId, multiIdDto.equipmentId))
            {
                return NotFound();
            }
            return new OkObjectResult(ticketRepository.GetByUserIdAndEquipmentId(multiIdDto.userId, multiIdDto.equipmentId));
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
            //Check exist id User
            if (!ticketRepository.CheckExistUserIdInUserTable(ticket.UserId))
            {
                return StatusCode(404, "UserId not exist");
            }
            //Check exist id Equipment
            if (!ticketRepository.CheckExistEquipmentIdInEquipmentTable(ticket.EquipmentId))
            {
                return StatusCode(404, "EquipmentId not exist");
            }
            //Check exist field
            if (ticketRepository.CheckExistUserIdAndEquipmentId(ticket.UserId, ticket.EquipmentId))
            {
                return StatusCode(400, "EquipmentId and UserId is exists, so not add field");
            }

            ticketRepository.CreateTicket(ticket);
            return new OkObjectResult(ticket);
        }

        //Update
        [HttpPut]  // api/ticket
        public ActionResult<List<Ticket>> Put([FromBody] Ticket ticket)
        {
            if (!ticketRepository.CheckExistUserIdAndEquipmentId(ticket.UserId, ticket.EquipmentId))
            {
                return StatusCode(400, "EquipmentId and UserId is not exists");
            }
            ticketRepository.UpdateTicket(ticket);
            return new OkObjectResult(ticket);
        }

        //Delete
        [HttpDelete()]  // api/ticket
        public ActionResult<List<Ticket>> Delete([FromBody] MultiIdDto multiIdDto)
        {
            if (!ticketRepository.CheckExistUserIdAndEquipmentId(multiIdDto.userId, multiIdDto.equipmentId))
            {
                return StatusCode(400, "EquipmentId and UserId is not exists");
            }
            ticketRepository.DeleteTicket(multiIdDto.userId, multiIdDto.equipmentId);
            return new OkObjectResult(ticketRepository.GetAllTicket());
        }
    }
}
