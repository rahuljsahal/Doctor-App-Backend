using DoctorAppBackend.Model.DTOs.Requests;
using DoctorAppBackend.Model.DTOs.Responses;
using DoctorAppBackend.Repository.Authenticaction;
using Microsoft.AspNetCore.Mvc;

namespace DoctorAppBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        public readonly IAuthentication _auth;
        public AuthenticationController(IAuthentication auth)
        {
            _auth = auth; 
        }
        [HttpPost]
        [Route("SignUp")]
        public async Task<IActionResult> SignUp(SignUpRequest request)
        {
            SignUpResponse response = new SignUpResponse();
            var result = await _auth.SignUp(request);
            if (result.IsSuccess)
                return Ok(result);

            return Unauthorized(result);

        }
        [HttpPost]
        [Route("SignIn")]
        public async Task<IActionResult> SignIn(SignInRequest request)
        { 
            if (!ModelState.IsValid)
             return BadRequest(ModelState);

            var result = await _auth.SignIn(request);
            if (result.IsLogin)
                return Ok(result);

            return Unauthorized(result);

        }
    }
}
