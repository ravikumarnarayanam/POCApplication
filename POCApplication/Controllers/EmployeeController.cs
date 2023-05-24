//using AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using POCApplication.Models;
using POCApplication.Repository;
using Microsoft.AspNetCore.Mvc.RazorPages;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace POCApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployee _employee;
        public EmployeeController(IEmployee emp)
        {
            _employee = emp ?? throw new ArgumentNullException(nameof(emp));
        }
        // GET: api/<EmployeeController>
        [HttpGet]
        [Route("GetAllEmployees")]
        public ActionResult Get()
        {            
            return Ok(_employee.GetEmployeeDetails().ToList());            
        }

        // GET api/<EmployeeController>/5
        [HttpGet]
        [Route("GetEmployeeByEmpID/{Id}")]
        public IActionResult GetEmployeedetailsById(int Id)
        {
            return Ok(_employee.GetEmployeeDetailsbyId(Id));
        }

        // POST api/<EmployeeController>
        [HttpPost]
        [Route("AddEmployee")]
        public async Task<IActionResult> Post(Employee emp)
        {
            var result = await _employee.InsertEmployee(emp);
            if (result.EmployeeId == 0)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Something Went Wrong");
            }
            return Ok("Added Successfully");
        }
        // PUT api/<EmployeeController>/5
        [HttpPut]
        [Route("UpdateEmployee")]
        public async Task<IActionResult> UpdateEmployee(Employee emp)
        {
            await _employee.UpdateEmployee(emp);
            return Ok("Updated Successfully");
        }

        [HttpDelete]
        //[HttpDelete("{id}")]
        [Route("DeleteEmployee/{Id}")]
        public JsonResult Delete(int Id)
        {
            _employee.DeleteEmployee(Id);
            return new JsonResult("Deleted Successfully");
        }
    }
}
