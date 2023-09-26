using HWRESTAPIS.Data;
using HWRESTAPIS.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Any;
using System.Reflection.Metadata;

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
        [HttpGet]
        public IActionResult GetCustById(int? Id) {

            if( Id == null || Id == 0 ) {
                IEnumerable<CustomerModel> list = _db.Customers;
                return new ObjectResult(null) { StatusCode = 200, Value = new { Message = "Success", Obj = list } };
            }
            else {
                var customer = _db.Customers.Find(Id);

                return customer == null ?
                 new ObjectResult(new {
                     Message = "Id " + Id + " Not Found",
                     Obj = Array.Empty<AnyType>()
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

        [HttpPost]
        public async Task<IActionResult> CreateCutomer([FromBody] CustomerModel customer) {

            if( ModelState.IsValid && customer != null ) {
                try {
                    _db.Customers.Add(customer);
                   await _db.SaveChangesAsync();
                    return new ObjectResult(new { Message = "Customer Created Successfully" }) { StatusCode = 201 };

                } catch( Exception se ) {
                    return new ObjectResult(new { Message = se.Message }) { StatusCode = 500 };
                }

            }
            else {
                return new ObjectResult(new { Message = "Please Provide Valid details" }) { StatusCode = 206 };
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditCutomer(int id, [FromBody] CustomerModel customer) {

            if( ModelState.IsValid && customer != null && id != 0 ) {

                try {

                   // var oldCustomer = await _db.Customers.FindAsync(id);
                    //if( oldCustomer != null ) {
                    if(id==customer.Id) { 
                        _db.Entry(customer).State = EntityState.Modified;
                       // _db.Customers.Update(customer);
                       await _db.SaveChangesAsync();
                        return new ObjectResult(new { Message = "Customer Updated Successfully" }) { StatusCode = 201 };

                    }
                    else
                        return new ObjectResult(new { Message = "Id" + id + " Not Found" }) { StatusCode = 206 };

                } catch( Exception se ) {
                    return new ObjectResult(new { Message = se.Message }) { StatusCode = 500 };
                }

            }
            else {
                return new ObjectResult(new { Message = "Please Provide Valid details" }) { StatusCode = 206 };
            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCutomer(int id) {

            if( id != 0 ) {

                try {

                    var oldCustomer = await _db.Customers.FindAsync(id);
                    if( oldCustomer != null ) {
                        _db.Customers.Remove(oldCustomer);
                       await _db.SaveChangesAsync();
                        return new ObjectResult(new { Message = "Customer Deleted Successfully" }) { StatusCode = 201 };

                    }
                    else
                        return new ObjectResult(new { Message = "Id " + id + " Not Found" }) { StatusCode = 206 };

                } catch( Exception se ) {
                    return new ObjectResult(new { Message = se.Message }) { StatusCode = 500 };
                }

            }
            else
                return new ObjectResult(new { Message = "Please Provide Valid details" }) { StatusCode = 206 };


        }
    }
}
