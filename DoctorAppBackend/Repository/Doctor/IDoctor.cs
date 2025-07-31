using DoctorAppBackend.Model.DTOs.Requests;
using DoctorAppBackend.Model.DTOs.Responses;
using DoctorAppBackend.Model.Entities;

namespace DoctorAppBackend.Repository.Doctor
{
    public interface IDoctor
    {
        Task<AddDoctorResponse> AddDoctorAsync(AddDoctorRequest request);
        Task<List<DepartmentMaster>> GetAllDeptAsync();
        Task<DeleteDoctorByIdResponse> DeleteDoctorAsync(DeleteDoctorByIdRequest request);
    }
}
