using DoctorAppBackend.Model.DTOs.Requests;
using DoctorAppBackend.Model.DTOs.Responses;

namespace DoctorAppBackend.Repository.Admin
{
    public class Admin : IAdmin
    {
        private readonly IConfiguration _configuration;
        public Admin(IConfiguration configuration)
        {
            _configuration = configuration;
            
        }
        public async Task<AdminPasscodeResponse> ValidatePasscodeAsync(AdminPasscodeRequest request)
        {
            var storedPasscode = _configuration["AdminSettings:Passcode"];
            var response = new AdminPasscodeResponse();

            if(request.Passcode== storedPasscode)
            {
                response.IsValid = true;
                response.Message = "Access Granted";
            }
            else
            {
                response.IsValid = false;
                response.Message = "Access Denied! Try again";
            }

            return await Task.FromResult(response);
        }
    }
}
