using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StorageFacility.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace StorageFacility.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        IProductLogic productLogic = new ProductLogic();


        [HttpPost]
        public IActionResult RegisterProduct(string barcode, string productName)
        {
            try
            {
                productLogic.RegisterProduct("", barcode, productName);
                return Ok();
            }
            catch
            {
                return StatusCode(400,"Test");
            }
        }


    }
}
