using DoctorAppBackend.Model.DTOs.Requests;

namespace DoctorAppBackend.Repository.UserRecords
{
    public interface IUpdateProfile
    {
        Task<bool> UpdateProfileAsync(string CurrentEmail, UpdatePatientRequest request);
    }
}
