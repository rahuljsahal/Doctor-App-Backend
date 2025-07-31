using DoctorAppBackend.Model.DTOs.Requests;
using DoctorAppBackend.Model.DTOs.Responses;
using DoctorAppBackend.Model.Entities;

namespace DoctorAppBackend.Repository.UserRecords
{
    public interface IConsult
    {
       public Task<ConsultDoctorResponse> Consult(ConsultDoctorRequest request);
        public Task<List<DepartmentMaster>> SearchByDepartmentAsync();
        public Task<List<Doctors>> GetDoctorsAsync();
    }
}
