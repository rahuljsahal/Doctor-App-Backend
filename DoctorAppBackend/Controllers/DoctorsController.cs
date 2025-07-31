using DoctorAppBackend.Model.DTOs.Requests;
using DoctorAppBackend.Repository.Doctor;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DoctorAppBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorsController : ControllerBase
    {
        private readonly IDoctor _doctor;

        public DoctorsController(IDoctor doctor)
        {
            _doctor = doctor;
            
        }
        [HttpGet("departments")]
        public async Task<IActionResult> GetAllDeptsAsync()
        {
            var depts = await _doctor.GetAllDeptAsync();
            return Ok(depts);
        }

        [HttpPost("addDoctor")]
        public async Task<IActionResult> AddDoctor(AddDoctorRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var result = await _doctor.AddDoctorAsync(request);
            if(result.DoctorAdded)
                return Ok(result);
            return Unauthorized(result);

        }
        [HttpDelete]
        [Route("deleteDoctor")]
        public async Task<IActionResult> DeleteDoctor(DeleteDoctorByIdRequest request)
        {
            var result = await _doctor.DeleteDoctorAsync(request);
            if (result.IsDeleted)
                return Ok(result);
            return Unauthorized(result);
        }
    }
}
