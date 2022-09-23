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
    public class OrdersController : ControllerBase
    {
       // private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);//
        private readonly IOrderItem _context;

        public OrdersController(IOrderItem context)
        {
            this._context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var result = _context.displayOrder();
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
        public async Task<IActionResult> Put([FromBody] Order order)
        {
            try
            {
                var result = _context.Put(order);
                return StatusCode(200, result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpDelete("{orderId}")]

        public async Task<IActionResult> Delete(int orderId)
        {
            try
            {
                var result = _context.Delete(orderId);
                return StatusCode(200, result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);

            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(Order order)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var result = _context.Post(order);
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
    
