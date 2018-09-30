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
    [Route("api/Game")]
    public class GameController : Controller {

        private readonly IGame service;

        public GameController(IGame _service) {
            service = _service;
        }

        /// <summary>
        /// List all Games.
        /// </summary>
        /// <returns>List with all Games</returns>
        [HttpGet]
        [Produces("application/json")]
        public IEnumerable<Game> GetAll() {

            return service.GetGames;
        }

        /// <summary>
        /// Lists the Game with corresponding id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>The corresponding Game</returns>
        /// <response code="200">Returns the expected Game</response>
        /// <response code="404">If no Game with the same id was found</response>
        [ProducesResponseType(typeof(Game), 200)]
        [ProducesResponseType(404)]
        [Produces("application/json")]
        [HttpGet("{id}", Name = "GetGame")]
        public IActionResult GetById(long id) {
            var game = service.GetGame(id);

            if (game == null) {
                return NotFound();
            }

            return Ok(game);
        }

        /// <summary>
        /// Creates a new Game.
        /// </summary>
        /// <param name="game"></param>
        /// <returns>The Game added</returns>
        /// <remarks>
        /// Request example:
        /// 
        ///     POST /game
        ///     {
        ///         "steamAppid": 1102,
        ///         "title": "Half-Life",
        ///         "shortDescription": "The best game ever.",
        ///         "detailedDescription": "Half-life is the best game ever...",
        ///         "headerImage": "https://steamcdn-a.akamaihd.net/steam/apps/1102/header.jpg",
        ///         "price": 25.90
        ///     }
        /// 
        /// </remarks>
        /// <response code="201">Returns the Game created</response>
        /// <response code="400">The Game passed is null</response>
        [ProducesResponseType(400)]
        [ProducesResponseType(typeof(Game), 201)]
        [Produces("application/json")]
        [HttpPost]
        public IActionResult Create([FromBody] Game game) {
            if (game == null) {
                return BadRequest();
            }

            service.Add(game);

            return CreatedAtRoute("GetGame", new { id = game.Id }, game);
        }

        /// <summary>
        /// Updates a Game.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="game"></param>
        /// <returns>No content</returns>
        /// <response code="400">If the Game passed is null or its id is different from the one passed on the url.</response>
        /// <response code="404">If no Game with the same id was found</response>
        /// <response code="204">Updated with success</response>
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [HttpPut("{id}")]
        public IActionResult Update(long id, [FromBody] Game game) {

            if (game == null || game.Id != id) {
                return BadRequest();
            }

            if (!service.Update(id, game)) {
                return NotFound();
            }

            return NoContent();
        }

        /// <summary>
        /// Deletes a Game.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>No content</returns>
        /// <response code="204">If no Game item with the same id was found</response>
        /// <response code="400">Deleted with success</response>
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [HttpDelete("{id}")]
        public IActionResult Delete(long id) {

            if (!service.Remove(id)) {
                return NotFound();
            }

            return NoContent();
        }
    }
}