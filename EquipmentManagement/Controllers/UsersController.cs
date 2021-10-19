using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Equipment.Models;
using System;
using Microsoft.AspNetCore.Http;
using Equipment.Repository;
using System.Text.Json;
using ConstantIns = Equipment.Constant.Constant;

namespace Equipment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private IUserRepository userRepository;

        public UsersController()
        {
            this.userRepository = new UserRepository(new EquipmentDBContext());
        }
        // GET api/users
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/users/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/users
        [HttpPost]
        public ActionResult<User> CreateUser([FromBody]User user)
        {
            try
            {
                if (user == null)
                    return BadRequest();
                userRepository.InsertUser(user);
                userRepository.Save();
                return StatusCode(StatusCodes.Status201Created, JsonSerializer.Serialize(user));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, Constant.Constant.FAIL_CREATE_USER);
            }
        }

        // PUT api/users/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] User user)
        {
            User targetUser = userRepository.GetUserByID(id);
        }

        // DELETE api/users/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try 
            {
                userRepository.DeleteUser(id);
                userRepository.Save();
                return StatusCode(StatusCodes.Status204NoContent);

            }
            catch(Exception)
            {
                return StatusCode(StatusCodes.Status404NotFound);
            }
        }
    }
}
