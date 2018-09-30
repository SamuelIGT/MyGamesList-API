using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyGamesListAPI.Models;
using MyGamesListAPI.Repository;
using MyGamesListAPI.Services;

namespace MyGamesListAPI.Controllers {

    [Produces("application/json")]
    [Route("api/User")]
    public class UserController : Controller {

        private readonly IUser service;

        public UserController(IUser _service) {
            service = _service;
        }


        /// <summary>
        /// List all Users.
        /// </summary>
        /// <returns>List with all Users</returns>
        [HttpGet]
        [Produces("application/json")]
        public IEnumerable<User> GetAll() => service.GetUsers;

        /// <summary>
        /// Lists the User with corresponding id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>User</returns>
        /// <response code="200">Returns the expected User</response>
        /// <response code="404">If no User with the same id was found</response>
        [Produces("application/json")]
        [ProducesResponseType(typeof(User), 200)]
        [ProducesResponseType(404)]
        [HttpGet("{id}", Name = "GetById")]
        public IActionResult GetById(long id) {
            var user = service.GetUser(id);
            if (user == null) {
                return NotFound();
            }

            return Ok(user);
        }

        /// <summary>
        /// Creates a new User.
        /// </summary>
        /// <param name="user"></param>
        /// <returns>User added</returns>
        /// <response code="201">Returns the User created</response>
        /// <response code="400">If the User is null</response>
        [ProducesResponseType(400)]
        [ProducesResponseType(typeof(User), 201)] //TEST IF IT RETURNS A OBJECT
        [Produces("application/json")]
        [HttpPost]
        public IActionResult Create([FromBody] User user) {
            if (user == null) {
                return BadRequest();
            }

            service.Add(user);
            return CreatedAtRoute("GetById", new { id = user.Id }, user);
        }


        /// <summary>
        /// Updates a User
        /// </summary>
        /// <param name="id"></param>
        /// <param name="user"></param>
        /// <returns>No content</returns>
        /// <response code="400">If the User passed is null or its id is different from the one passed on the url.</response>
        /// <response code="404">If no User with the same id was found</response>
        /// <response code="204">Updated with success</response>
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [HttpPut("{id}")]
        public IActionResult Update(long id, [FromBody] User user) {
            if (user == null || user.Id != id) {
                return BadRequest();
            }

            if (!service.Update(id, user)) {
                return NotFound();
            }

            return NoContent();

        }

        /// <summary>
        /// Deletes a User
        /// </summary>
        /// <param name="id"></param>
        /// <returns>No content</returns>
        /// <response code="404">If no User with the same id was found</response>
        /// <response code="204">Deleted with success</response>
        [ProducesResponseType(404)]
        [ProducesResponseType(204)]
        [HttpDelete("{id}")]
        public IActionResult Delete(long id) {
            if (!service.Remove(id)) {
                return NotFound();
            }
            return NoContent();
        }

    }
}