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
        // Initiating the Product Logic
        IProductLogic productLogic = new ProductLogic();

        /// <summary>
        /// Registers a product through HTTPPost
        /// using Product Logic Method
        /// </summary>
        /// <param name="barcode"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult RegisterProduct(string barcode, string name)
        {
            try
            {
                productLogic.RegisterProduct("", barcode, name);
                return Ok();
            }
            catch
            {
                return StatusCode(400,"Test");
            }
        }

        /// <summary>
        /// Get Products through HTTPGet
        /// with product logic method
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetProducts()
        {
            try
            {
                return Ok(productLogic.GetProducts());
            }
            catch (Exception e)
            {

                return StatusCode(StatusCodes.Status400BadRequest, e.Message);
            }
        }
    }
}
