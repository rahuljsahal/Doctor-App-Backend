using DoctorAppBackend.Context;
using DoctorAppBackend.Model.DTOs.Responses;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace DoctorAppBackend.Repository.UserRecords
{
    public class Profile : IProfile
    {

        private readonly AppDbContext _context;
        public Profile(AppDbContext context)
        {
            _context = context;
            
        }
        public async Task<UserProfileResponse> UserDetails(string email)
        {
            var user = await _context.Patients.FirstOrDefaultAsync(u => u.Email == email);
            UserProfileResponse response = new UserProfileResponse();
            if(user == null)
            {
                return null;
            }
            return new UserProfileResponse
            {
                PatientId = user.PatientId,
                PatientName = user.Name,
                Email = user.Email,
                Dob = user.DOB,
                Phno = user.PhoneNo
            };
            
        }
    }
}
