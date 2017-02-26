using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Asp.netCoreExample.Models;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Asp.netCoreExample.Controllers
{
    [Route("api/[controller]")]
    public class CustomersController : Controller
    {
        TestDBContext _db = new TestDBContext();
        [HttpGet]
       public async Task<IActionResult> Get()
        {
            var result = await _db.Customer.ToListAsync();

            return Ok(result);
        }

        //[Route("api/customers/{id}",Name ="GetCustomer")]
        [HttpGet("{id}", Name = "GetCustomer")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _db.Customer.Where(c => c.Id == id).FirstOrDefaultAsync();

            return Ok(result);
        }

        //[ProducesResponseType(typeof(Customer),200)]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Customer customer)
        {
            try
            {
                var result = _db.Customer.Add(customer);
                await _db.SaveChangesAsync();
                // return Ok(customer);
                //return CreatedAtRoute("DefaultApi", new {controller="customers", id = customer.Id }, customer);
                return CreatedAtRoute("GetCustomer", new { id = customer.Id }, customer);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }
}
