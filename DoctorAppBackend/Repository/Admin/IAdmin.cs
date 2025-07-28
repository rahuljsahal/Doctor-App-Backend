using DoctorAppBackend.Model.DTOs.Requests;
using DoctorAppBackend.Model.DTOs.Responses;

namespace DoctorAppBackend.Repository.Admin
{
    public interface IAdmin
    {
        Task<AdminPasscodeResponse> ValidatePasscodeAsync(AdminPasscodeRequest request);
    }
}
