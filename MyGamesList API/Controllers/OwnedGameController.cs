using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyGamesListAPI.Models;
using MyGamesListAPI.Services;

namespace MyGamesListAPI.Controllers {
    [Produces("application/json")]
    [Route("api/OwnedGame")]
    public class OwnedGameController : Controller {
        private readonly IOwnedGame service;

        public OwnedGameController(IOwnedGame _service) {
            service = _service;
        }

        /// <summary>
        /// Lists all OwnedGames
        /// </summary>
        /// <returns>List with all OwnedGames</returns>
        [Produces("application/json")]
        [HttpGet]
        public IEnumerable<OwnedGame> GetAll() => service.GetOwnedGames;

        /// <summary>
        /// Lists the OwnedGame with corresponding id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>OwnedGame</returns>
        /// <response code="200">Returns the expected OwnedGame</response>
        /// <response code="404">If no OwnedGame with the same id was found</response>
        [ProducesResponseType(typeof(OwnedGame), 200)]
        [ProducesResponseType(404)]
        [Produces("application/json")]
        [HttpGet("{id}", Name = "GetOwnedGame")]
        public IActionResult GetById(long id) {
            OwnedGame game = service.GetOwnedGame(id);
            if (game == null) {
                return NotFound();
            }
            return Ok(null);
        }

        /// <summary>
        /// Creates a new OwnedGame.
        /// </summary>
        /// <param name="game"></param>
        /// <returns>OwnedGame added</returns>
        /// <response code="201">Returns the OwnedGame created</response>
        /// <response code="400">If the OwnedGame is null</response>
        [ProducesResponseType(typeof(OwnedGame), 201)]
        [ProducesResponseType(400)]
        [Produces("application/json")]
        [HttpPost]
        public IActionResult Create([FromBody] OwnedGame game) {
            if (game == null) {
                return BadRequest();
            }

            service.Add(game);
            return CreatedAtRoute("GetOwnedGame", new { id = game.Id }, game);
        }

        /// <summary>
        /// Updates the OwnedGame.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="game"></param>
        /// <returns>No content</returns>
        /// <response code="400">If the OwnedGame passed is null or its id is different from the one passed on the url.</response>
        /// <response code="404">If no OwnedGame with the same id was found</response>
        /// <response code="204">Updated with success</response>
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        [HttpPut("{id}")]
        public IActionResult Update(long id, [FromBody] OwnedGame game) {
            if (game == null || id != game.Id) {
                return BadRequest();
            }

            if (!service.Update(id, game)) {
                return NotFound();
            }

            return NoContent();
        }

        /// <summary>
        /// Deletes the OwnedGame.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>No content</returns>
        /// <response code="404">If no OwnedGame with the same id was found</response>
        /// <response code="204">Deleted with success</response>
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        [HttpDelete("{id}")]
        public IActionResult Delete(long id) {
            if (!service.Remove(id)) {
                return NotFound();
            }
            return NoContent();
        }


    }
}