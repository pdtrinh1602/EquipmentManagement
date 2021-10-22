using Equipment.Constant;
using Equipment.Models;
using EquipmentManagement.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text.Json;
using EquipmentModel = Equipment.Models.Equipment;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EquipmentManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EquipmentsController : ControllerBase
    {
        private readonly IEquipmentRepository equipmentRepository;

        public EquipmentsController()
        {
            this.equipmentRepository = new EquipmentRepository(new EquipmentDBContext());
        }

        // GET: api/<EquipmentController>
        [HttpGet]
        public ActionResult<string> Get()
        {
            try
            {
                var equipmentList = equipmentRepository.GetEquipment();
                return StatusCode(StatusCodes.Status200OK, JsonSerializer.Serialize(equipmentList));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        // GET api/<EquipmentController>/5
        [HttpGet("{id}")]
        public ActionResult<string> GetById(int id)
        {
            try
            {
                var equipment = equipmentRepository.GetEquipmentById(id);
                return StatusCode(StatusCodes.Status200OK, JsonSerializer.Serialize(equipment));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        // GET api/<EquipmentController>/5
        [HttpGet("equipment-name/{equipmentName}")]
        public ActionResult<string> SearchEquipment(string equipmentName)
        {
            try
            {
                List<EquipmentModel> equipment = equipmentRepository.SearchEquipment(equipmentName);
                return StatusCode(StatusCodes.Status200OK, JsonSerializer.Serialize(equipment));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        // POST api/<EquipmentController>
        [HttpPost]
        public ActionResult<string> Post([FromBody] EquipmentModel value)
        {
            try
            {
                equipmentRepository.CreateEquipmnet(value);
                return StatusCode(StatusCodes.Status201Created, JsonSerializer.Serialize(value));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, Constant.FAIL_CREATE_EQUIPMENT);
            }
        }

        // PUT api/<EquipmentController>/5
        [HttpPut("{id}")]
        public ActionResult<string> Put(int id, [FromBody] EquipmentModel value)
        {
            try
            {
                EquipmentModel equipment = equipmentRepository.GetEquipmentById(id);

                if (!String.IsNullOrEmpty(value.EquipmentName))
                {
                    equipment.EquipmentName = value.EquipmentName;
                }
                if (!String.IsNullOrEmpty(value.Description))
                {
                    equipment.Description = value.Description;
                }
                if (!String.IsNullOrEmpty(value.Type))
                {
                    equipment.Type = value.Type;
                }
                if (value.IsAvailable)
                {
                    equipment.IsAvailable = value.IsAvailable;
                }

                equipmentRepository.Save();

                return StatusCode(StatusCodes.Status200OK, equipment);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        // DELETE api/<EquipmentController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                EquipmentModel targeEquipment = equipmentRepository.GetEquipmentById(id);
                if(targeEquipment == null)
                {
                    return new NotFoundResult();
                }
                equipmentRepository.DeleteEquipmnet(id);
                return new NoContentResult();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Delete Fail");
            }
        }
    }
}
