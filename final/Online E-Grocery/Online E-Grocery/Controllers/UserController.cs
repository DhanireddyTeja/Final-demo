using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using log4net;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Online_E_Grocery.Core.Interface;
using Online_E_Grocery.DataAccess;
using Online_E_Grocery.Models;

namespace Online_E_Grocery.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private readonly IUser _context;
        public UserController(IUser _context)
        {
            this._context = _context;
        }
        [HttpGet]
        public async Task<IActionResult> displayUser()
        {
            try
            {
                var result = _context.displayUser();
                log.Info("Data is Displayed");
                return StatusCode(200, result);
            }
            catch (Exception)
            {
                log.Error("Error occur");
                return StatusCode(StatusCodes.Status500InternalServerError, "Error Retrieving Data from the Database");
            }
        }
        [HttpPut("Put")]
        public async Task<IActionResult> put([FromBody] User user)
        {
            try
            {
                var result = _context.Put(user);
                return StatusCode(200, result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpDelete("Delete")]

        public async Task<IActionResult> Delete(int Id)
        {
            try
            {
                var result = _context.Delete(Id);
                return StatusCode(200, result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);

            }
        }
        [HttpPost]
        public async Task<IActionResult> Post(User user)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var result = _context.Post(user);
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
