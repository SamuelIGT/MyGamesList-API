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
    [Route("api/WishlistItem")]
    public class WishlistItemController : Controller {

        private readonly IWishlistItem service;

        public WishlistItemController(IWishlistItem _service) {
            service = _service;
        }

        /// <summary>
        /// Lists all WishlistItems.
        /// </summary>
        /// <returns>List with all WishlistItems.</returns>
        [Produces("application/json")]
        [HttpGet]
        public IEnumerable<WishlistItem> GetAll() => service.GetWishlistItems;

        /// <summary>
        /// Lists the WishlistItem with the corresponding id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>WishlistItem</returns>
        /// <response code="200">Returns the expected WishlistItem</response>
        /// <response code="404">If no WishlistItem with the same id was found</response>
        [ProducesResponseType(404)]
        [ProducesResponseType(typeof(WishlistItem), 200)]
        [Produces("application/json")]
        [HttpGet("{id}", Name = "GetWishlistItem")]
        public IActionResult GetById(long id) {
            WishlistItem item = service.GetWishlistItem(id);

            if (item == null) {
                return NotFound();
            }

            return Ok(item);
        }

        /// <summary>
        /// Creates a new WishlistItem.
        /// </summary>
        /// <param name="item"></param>
        /// <returns>WishlistItem created</returns>
        /// <response code="201">Returns the WishlistItem created</response>
        /// <response code="400">If the WishlistItem is null</response>
        [ProducesResponseType(400)]
        [ProducesResponseType(typeof(WishlistItem), 201)]
        [Produces("application/json")]
        [HttpPost]
        public IActionResult Create([FromBody] WishlistItem item) {
            if (item == null) {
                return BadRequest();
            }

            service.Add(item);
            return CreatedAtRoute("GetWishlistItem", new {id = item.Id}, item);
        }

        /// <summary>
        /// Updates the WishlistItem.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="item"></param>
        /// <returns>No content</returns>
        /// <response code="400">If the WishlistItem passed is null or its id is different from the one passed on the url.</response>
        /// <response code="404">If no WishlistItem with the same id was found</response>
        /// <response code="204">Updated with success</response>
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(204)]
        [HttpPut("{id}")]
        public IActionResult Update(long id, [FromBody] WishlistItem item) {
            if(item == null || id != item.Id) {
                return BadRequest();
            }

            if(!service.Update(id, item)) {
                return NotFound();
            }

            return NoContent();
        }

        /// <summary>
        /// Deletes the WishlistItem.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>No Content</returns>
        /// <response code="404">If no WishlistItem with the same id was found</response>
        /// <response code="204">Deleted with success</response>
        [ProducesResponseType(404)]
        [ProducesResponseType(204)]
        [HttpDelete("{id}")]
        public IActionResult Delete(long id) {
            if (!service.Remove(id)) {
                return BadRequest();
            }

            return NoContent();
        }
    }
}