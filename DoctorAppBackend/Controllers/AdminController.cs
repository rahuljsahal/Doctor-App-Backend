using DoctorAppBackend.Model.DTOs.Requests;
using DoctorAppBackend.Repository.Admin;
using Microsoft.AspNetCore.Mvc;

namespace DoctorAppBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IAdmin _admin;
        private readonly IDepartment _dept;
        public AdminController(IAdmin admin, IDepartment dept)
        {
            _admin = admin;
            _dept = dept;
            
        }

        [HttpPost]
        [Route("admin-pass")]
        public async Task<IActionResult> VerifyPasscode(AdminPasscodeRequest request)
        {
            var result = await _admin.ValidatePasscodeAsync(request);
            if (result.IsValid)
                return Ok(result);
            return Unauthorized(result);
        }
        [HttpPost]
        [Route("addDept")]
        public async Task<IActionResult> AddDept(AddDepartmentRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var result = await _dept.AddDept(request);
            if (result.DeptAdded)
                return Ok(result);
            return Unauthorized(result);
        }
    }
}
