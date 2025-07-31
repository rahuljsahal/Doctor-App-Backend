using DoctorAppBackend.Model.DTOs.Requests;
using DoctorAppBackend.Repository.UserRecords;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DoctorAppBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConsultController : ControllerBase
    {
        private readonly IConsult _consult;
        public ConsultController(IConsult consult)
        {
            _consult = consult;
        }
        [HttpGet("doctors")]
        public async Task<IActionResult> GetAllDoctorsAsync()
        {
            var docs = await _consult.GetDoctorsAsync();
            return Ok(docs);
        }

        [HttpGet("department")]
        public async Task<IActionResult> SearchByDeptsAsync()
        {
            var depts = await _consult.SearchByDepartmentAsync();
            return Ok(depts);
        }

        [HttpPost]
        [Route("consult")]
        public async Task<IActionResult> AddConsult(ConsultDoctorRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var result = await _consult.Consult(request);
            if (result.IsSucess)
                return Ok(result);
            return Unauthorized(result);
        }
       
    }
}
