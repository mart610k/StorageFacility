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
    public class RackController : ControllerBase
    {
        // Initialize Rack Logic
        IRackLogic rackLogic = new RackLogic();
        /// <summary>
        /// Register a new Rack, through HTTPPost
        /// with RackLogic method
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult RegisterRack(string name)
        {
            try
            {
                rackLogic.RegisterRack(name);
                return Ok();
            }
            catch(Exception e)
            {
                return StatusCode(StatusCodes.Status400BadRequest, e.Message);
            }

        }

        /// <summary>
        /// Get all Racks, through a HTTPGet
        /// with RackLogic Method
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetRacks()
        {
            try
            {
                return Ok(rackLogic.GetRacks());
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status400BadRequest, e.Message);
            }
        }

    }
}
