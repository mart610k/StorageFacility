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
        IShelfLogic shelfLogic = new ShelfLogic();
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
    }
}
