using DoctorAppBackend.Model.DTOs.Requests;
using DoctorAppBackend.Repository.UserRecords;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationModels;

namespace DoctorAppBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfileController : ControllerBase
    {
        public readonly IProfile _profile;
        public readonly IUpdateProfile _updateProfile;
        public ProfileController(IProfile profile , IUpdateProfile updateProfile)
        {
            _profile = profile;
            _updateProfile = updateProfile;
            
        }
        [HttpGet]
        [Route("GetUserDetails")]
        public async Task<IActionResult> GetUserDetails(string email)
        {
            var result = await _profile.UserDetails(email);
            if (result == null)
                return NotFound(new { msg = "User not found" });

            return Ok(result);
        }
        [HttpPut]
        [Route("updateProfile")]
        public async Task<IActionResult> UpdateProfile(UpdatePatientRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var currentEmail = request.Email;
            var result = await _updateProfile.UpdateProfileAsync(currentEmail, request);
            if (!result)
                return NotFound(new { msg = "Error while updating" });
            return Ok(new { msg = "Profile Updated Successfully" });
        }
        [HttpDelete]
        [Route("deletePatient")]
        public async Task<IActionResult> DeletePatientAsync(DeletePatientByIdRequest request)
        {
            var result = await _profile.DeletePatient(request);
            if (result.IsDeleted)
                return Ok(result);
            return Unauthorized(result);
        }
    }
    
}
