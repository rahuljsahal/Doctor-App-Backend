using DoctorAppBackend.Context;
using DoctorAppBackend.Model.DTOs.Requests;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace DoctorAppBackend.Repository.UserRecords
{
    public class UpdateProfile : IUpdateProfile
    {
        private readonly AppDbContext _context;
        public UpdateProfile(AppDbContext context)
        {
            _context = context;
        }
        public async Task<bool> UpdateProfileAsync(string CurrentEmail, UpdatePatientRequest request)
        {
            var Patient = await _context.Patients.FirstOrDefaultAsync(p => p.Email == CurrentEmail);
            if(Patient == null)
            {
                return false;
            }
            Patient.Email = request.Email;
            Patient.PhoneNo = request.Phno;

            await _context.SaveChangesAsync();
            return true;
            
        }
    }
}
