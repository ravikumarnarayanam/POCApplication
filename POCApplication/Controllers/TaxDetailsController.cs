using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using POCApplication.Models;
using POCApplication.Repository;

namespace POCApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaxDetailsController : ControllerBase
    {
        private readonly ITaxDetails _taxdetails;
        public TaxDetailsController(ITaxDetails taxdetails)
        {
            _taxdetails = taxdetails ?? throw new ArgumentNullException(nameof(taxdetails));
        }
        // GET: api/<TaxDetailsController>
        [HttpGet]
        [Route("GetAllTaxDetails")]
        public IActionResult Get()
        {
            return Ok(_taxdetails.GetAllTaxDetails());
        }

        // GET api/<TaxDetailsController>/5
        [HttpGet]
        [Route("GetTaxDetailsByFinancialYear/{fy}")]
        public List<TaxDetails> GetTaxDetailsdetailsByFY(string fy)
        {
            return _taxdetails.GetTaxDetailsByFY(fy).ToList();
        }

        // POST api/<TaxDetailsController>
        [HttpPost]
        [Route("AddTaxDetails")]
        public async Task<IActionResult> Post(TaxDetails taxdetails)
        {
            var result = await _taxdetails.InsertTaxDetails(taxdetails);
            if (result.TaxRate == 0)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Something Went Wrong");
            }
            return Ok("Added Successfully");
        }
        // PUT api/<TaxDetailsController>/5
        [HttpPut]
        [Route("UpdateTaxDetails")]
        public async Task<IActionResult> UpdateTaxDetails(TaxDetails taxdetails)
        {
            await _taxdetails.UpdateTaxDetails(taxdetails);
            return Ok("Updated Successfully");
        }

        [HttpDelete]
        //[HttpDelete("{id}")]
        [Route("DeleteTaxDetails/{Id}")]
        public JsonResult Delete(int Id)
        {
            _taxdetails.DeleteTaxDetails(Id);
            return new JsonResult("Deleted Successfully");
        }

        [HttpGet]
        [Route("GetTaxDetailsByEId/{empid}")]
        public EmpTaxCalculation GetTaxDetailsdetailsByEmpId(int empid)
        {
            return _taxdetails.TaxCalculation(empid);
        }
    }
}
