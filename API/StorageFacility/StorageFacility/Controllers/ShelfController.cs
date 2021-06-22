using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StorageFacility.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StorageFacility.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShelfController : ControllerBase
    {
        // Initiating Shelf Logic
        IShelfLogic shelfLogic = new ShelfLogic();

        /// <summary>
        /// Register Shelf through HTTPPost
        /// with Shelf Logic Method
        /// </summary>
        /// <param name="name"></param>
        /// <param name="rackName"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult RegisterShelf(string name, string rackName)
        {
            try
            {
                shelfLogic.RegisterShelf(name, rackName);
                return Ok();
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status400BadRequest, e.Message);
            }
        }

        /// <summary>
        /// Finds a product based on product id
        /// with shelf logic method
        /// </summary>
        /// <param name="productID"></param>
        /// <returns></returns>
        [HttpGet("find/product")]
        public IActionResult GetProductFromShelves(string productID)
        {
            try
            {
                return Ok(shelfLogic.GetShelvesContainingProductByID("", productID));
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status400BadRequest, e.Message);
            }
        }

        /// <summary>
        /// Adds a product to a shelf based on inputs
        /// with shelf logic method
        /// </summary>
        /// <param name="rackName"></param>
        /// <param name="shelfName"></param>
        /// <param name="barcode"></param>
        /// <returns></returns>
        [HttpPost("AddToShelf")]
        public IActionResult AddProductToShelf(string rackName, string shelfName, string barcode)
        {
            try
            {
                shelfLogic.AddProductToShelf(rackName, shelfName, barcode);
                return Ok();
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status400BadRequest, e.Message);
            }
        }

        /// <summary>
        /// Get's shelves from API
        /// with Shelf logic Method
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetShelves()
        {
            try
            {
                return Ok(shelfLogic.GetShelves());
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status400BadRequest, e.Message);
            }
        }
    }
}
