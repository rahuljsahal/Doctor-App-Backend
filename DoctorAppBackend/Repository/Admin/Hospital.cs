using DoctorAppBackend.Context;
using DoctorAppBackend.Model.DTOs.Requests;
using DoctorAppBackend.Model.DTOs.Responses;
using DoctorAppBackend.Model.Entities;
using DoctorAppBackend.Services.IdService;
using Microsoft.EntityFrameworkCore;

namespace DoctorAppBackend.Repository.Admin
{
    public class Hospital : IHospital
    {
        private readonly AppDbContext _context;
        private readonly IGenerateId _generateId;
        public Hospital(AppDbContext context, IGenerateId generateId)
        {
            _context = context;
            _generateId = generateId;
            
        }
        public async Task<AddHospitalResponse> AddHospitalAsync(AddHospitalRequest request)
        {
            var exists = await _context.Hospitals.FirstOrDefaultAsync(h => h.HospitalName == request.HospitalName);
            if (exists != null)
            {
                return new AddHospitalResponse
                {
                    IsSuccess = false,
                    Message = "Hospital Already Exists"
                };
            }
            string HospitalId = _generateId.GenerateHospitalId();
            var hospital = new Hospitals
            {
                HospitalCode = HospitalId,
                HospitalName = request.HospitalName

            };
            _context.Add(hospital);
            await _context.SaveChangesAsync();

            return new AddHospitalResponse
            {
                IsSuccess = true,
                Message = "Hospital Added",
                HospitalCode = HospitalId
            };

        }
    }
}
