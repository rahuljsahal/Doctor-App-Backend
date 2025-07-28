using DoctorAppBackend.Model.DTOs.Requests;
using DoctorAppBackend.Model.DTOs.Responses;

namespace DoctorAppBackend.Repository.Admin
{
    public interface IDepartment
    {
        Task<AddDepartmentResponse> AddDept(AddDepartmentRequest request);
    }
}
