using DoctorAppBackend.Context;
using DoctorAppBackend.Model.DTOs.Requests;
using DoctorAppBackend.Model.DTOs.Responses;
using DoctorAppBackend.Model.Entities;
using DoctorAppBackend.Services.IdService;
using Microsoft.EntityFrameworkCore;

namespace DoctorAppBackend.Repository.UserRecords
{
    public class Consult : IConsult
    {
        private readonly AppDbContext _context;
        private readonly IGenerateId _generateId;
        public Consult(AppDbContext context, IGenerateId generateId)
        {
            _context = context;
            _generateId = generateId;
            
        }

        public async Task<List<Doctors>> GetDoctorsAsync()
        {
            return await _context.Doctors.ToListAsync();
        }

        public async Task<double> GetFeeAsync(string DoctorId)
        {
            var doctor = await _context.Doctors.FirstOrDefaultAsync(d => d.DoctorId == DoctorId);
                return doctor.ConsultFee;
        }

        public async Task<List<DepartmentMaster>> SearchByDepartmentAsync()
        {
            return await _context.Departments.ToListAsync();
        }

        async Task<ConsultDoctorResponse> IConsult.Consult(ConsultDoctorRequest request)
        {
            var ConsultId = await _context.Consultations.FirstOrDefaultAsync(c => c.Aadhar == request.Aadhar);
            if (ConsultId != null)
                return new ConsultDoctorResponse
                {
                    IsSucess = false,
                    Message = "Already Registered"
                };
            var CId = _generateId.GenerateConsultId();
            var Con = new Consultations
            {
                ConsultId = CId,
                Aadhar = request.Aadhar,
                Name = request.Name,
                ConsultingDept = request.ConsultingDept,
                ConsultingDoctor = request.ConsultingDoctor,
                Date = request.Date,
                ConsultFee = request.ConsultFee
            };
            _context.Add(Con);
            await _context.SaveChangesAsync();

            return new ConsultDoctorResponse
            {
                IsSucess = true,
                ConsultationId = CId,
                Message = "Registered Successfully"
            };
            
            
        }
    }
}
