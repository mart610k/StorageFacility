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
        IRackLogic rackLogic = new RackLogic();
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

    }
}
