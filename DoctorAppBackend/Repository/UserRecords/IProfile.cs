﻿using DoctorAppBackend.Model.DTOs.Requests;
using DoctorAppBackend.Model.DTOs.Responses;

namespace DoctorAppBackend.Repository.UserRecords
{
    public interface IProfile
    {
        public Task<UserProfileResponse> UserDetails(string email);
        public Task<DeletePatientByIdResponse> DeletePatient(DeletePatientByIdRequest request);
    }
}
