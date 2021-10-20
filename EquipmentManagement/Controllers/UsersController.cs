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
        private UserRepository userRepository;

        public UsersController()
        {
            this.userRepository = new UserRepository(new EquipmentDBContext());
        }
        // GET api/users
        [HttpGet]
        public ActionResult<IEnumerable<User>> Get()
        {
            IEnumerable<User> listUser = userRepository.GetUsers();
            return StatusCode(StatusCodes.Status200OK, JsonSerializer.Serialize(listUser));
        }

        // GET api/users/5
        [HttpGet("{id}")]
        public ActionResult<User> Get(int id)
        {
            User targetUser = userRepository.GetUserByID(id);
            //return StatusCode(StatusCodes.Status200OK, JsonSerializer.Serialize(targetUser));
            return new OkObjectResult(targetUser);
        }

        [HttpGet("searchs")]
        public ActionResult<User> Get(string username)
        {
            IEnumerable<User> result = userRepository.GetUsersByConditions(username);
            //return StatusCode(StatusCodes.Status200OK, JsonSerializer.Serialize(result));
            return new OkObjectResult(result);
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
        public ActionResult Put(int id, [FromBody] User user)
        {
            try
            {
                User targetUser = userRepository.GetUserByID(id);
                if (targetUser == null)
                {
                    return StatusCode(StatusCodes.Status204NoContent);
                }
                userRepository.UpdateUser(id, user);
                userRepository.Save();
                return StatusCode(StatusCodes.Status200OK);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
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
