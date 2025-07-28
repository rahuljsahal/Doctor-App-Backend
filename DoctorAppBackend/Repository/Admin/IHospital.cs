using DoctorAppBackend.Model.DTOs.Requests;
using DoctorAppBackend.Model.DTOs.Responses;

namespace DoctorAppBackend.Repository.Admin
{
    public interface IHospital
    {
        Task<AddHospitalResponse> AddHospitalAsync(AddHospitalRequest request);
    }
}
