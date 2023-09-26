using HWRESTAPIS.Data;
using HWRESTAPIS.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Collections.Generic;
using System.Text.Json.Nodes;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HWRESTAPIS.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase {
        private readonly ApplicationDbContext _db;
        public CustomerController(ApplicationDbContext db) {
            _db = db;
        }
        // GET: api/<CustomerController>
        /*[HttpGet]
        public IActionResult getAllCustomers() {
            IEnumerable<CustomerModel> list = _db.Customers;
            return new ObjectResult(null) { StatusCode = 200, Value = new { Message = "Success", Obj = list } };
        }
*/

        // GET api/<CustomerController>/5
        [HttpGet("{Id}")]
        public async Task<IActionResult> GetCustById(int Id) {

            if( Id == 0 ) {
                IEnumerable<CustomerModel> list = _db.Customers;
                return new ObjectResult(null) { StatusCode = 200, Value = new { Message = "Success", Obj = list } };
            }
            else {
                var customer = await _db.Customers.FindAsync(Id);

                return customer == null ?
                 new ObjectResult(new {
                     Message = "Id " + Id + " Not Found",
                     Obj = new Object[] { }
                 }) {
                     StatusCode = 200
                 } : new ObjectResult(new {
                     Message = "Success",
                     Obj = new Object[] { customer }
                 }) {
                     StatusCode = 200
                 };
            }
        }


    }
}
