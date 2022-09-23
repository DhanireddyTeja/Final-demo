using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using log4net;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Online_E_Grocery.DataAccess;
using Online_E_Grocery.Models;
using Online_E_Grocery.Core.Interface;

namespace Online_E_Grocery.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RatingController : ControllerBase
    {
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private readonly IItemRating _context;
        public RatingController(IItemRating _context)
        {
            this._context = _context;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var result = _context.displayRating();
                log.Info("Data is Displayed");
                return StatusCode(200, result);
            }
            catch (Exception)
            {
                log.Error("Error occur");
                return StatusCode(StatusCodes.Status500InternalServerError, "Error Retrieving Data from the Database");
            }
        }


        [HttpPut]
        public async Task<IActionResult> Put([FromBody] Rating rating)
        {
            try
            {
                var result = _context.Put(rating);
                return StatusCode(200, result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpDelete]

        public async Task<IActionResult> Delete(int ratingId)
        {
            try
            {
                var result = _context.Delete(ratingId);
                return StatusCode(200, result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);

            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(Rating rating)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var result = _context.Post(rating);
                    log.Error("Created Successfully");
                    return StatusCode(200, "Created Successfully");
                }
                else
                {
                    log.Error("No Data");
                    return BadRequest("No Data");
                }
            }
            catch (Exception)
            {
                log.Error("Error occur");
                return StatusCode(StatusCodes.Status500InternalServerError, "Error Adding Data to the Database");
            }
        }
    }
}
