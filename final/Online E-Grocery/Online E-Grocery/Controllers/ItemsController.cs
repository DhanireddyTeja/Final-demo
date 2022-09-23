using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Online_E_Grocery.Core.Interface;
using Online_E_Grocery.DataAccess;
using Online_E_Grocery.Models;
using Microsoft.EntityFrameworkCore;

namespace Online_E_Grocery.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private readonly IItems _context;

        public ItemsController(IItems context)
        {
           this. _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var result = _context.Get();
               // log.Info("Data is Displayed");
                return StatusCode(200, result);
            }
            catch (Exception)
            {
                log.Error("Error occur");
                return StatusCode(StatusCodes.Status500InternalServerError, "Error Retrieving Data from the Database");
            }
        }

        [HttpGet("{itemName}")]
        public async Task<ActionResult<Items>> GetItems(string itemName)
        {
            try
            {
                log.Info("Item get sucessfulyy");
                var result = await _context.GetItems(itemName);
                if (result == null)
                {
                    return NotFound();
                }
                return result;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error Retrieving Data from the Database");
            }
        }
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] Items model)
        {
            try
            {
                var result = _context.Put(model);
                return StatusCode(200, result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpDelete("{itemId}")]

        public async Task<IActionResult> Delete(int itemId)
        {
            try
            {
                var result = _context.Delete(itemId);
                return StatusCode(200, result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);

            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(Items items)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var result = _context.Post(items);
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
