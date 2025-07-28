using DoctorAppBackend.Model.DTOs.Requests;
using DoctorAppBackend.Model.DTOs.Responses;
using DoctorAppBackend.Model.Entities;

namespace DoctorAppBackend.Repository.Authenticaction
{
    public interface IAuthentication
    {
        public Task<SignUpResponse> SignUp(SignUpRequest resquest);
        public Task<SignInResponse> SignIn(SignInRequest request);
        
    }
}
