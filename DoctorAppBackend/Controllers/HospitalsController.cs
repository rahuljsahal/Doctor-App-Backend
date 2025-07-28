using DoctorAppBackend.Model.DTOs.Requests;
using DoctorAppBackend.Repository.Admin;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DoctorAppBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HospitalsController : ControllerBase
    {
        private readonly IHospital _hospital;
        public HospitalsController(IHospital hospital)
        {
            _hospital = hospital;
        }

        [HttpPost]
        [Route("add-hospital")]
        public async Task<IActionResult> AddHospital(AddHospitalRequest request)
        {
            var result = await _hospital.AddHospitalAsync(request);
            if (result.IsSuccess)
                return Ok(result);
            return Unauthorized(result);
        }
    }

}
