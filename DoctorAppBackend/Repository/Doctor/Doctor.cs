using DoctorAppBackend.Context;
using DoctorAppBackend.Model.DTOs.Requests;
using DoctorAppBackend.Model.DTOs.Responses;
using DoctorAppBackend.Model.Entities;
using DoctorAppBackend.Services.IdService;
using Microsoft.EntityFrameworkCore;

namespace DoctorAppBackend.Repository.Doctor
{
    public class Doctor : IDoctor
    {

        private readonly AppDbContext _context;
        private readonly IGenerateId _generateId;
        public Doctor(AppDbContext context, IGenerateId generateId)
        {
            _context = context;
            _generateId = generateId;
            
        }

        
        public async Task<List<DepartmentMaster>> GetAllDeptAsync()
        {
            return await _context.Departments.ToListAsync();
        }
        public async Task<AddDoctorResponse> AddDoctorAsync(AddDoctorRequest request)
        {
            AddDoctorResponse response = new AddDoctorResponse();

            var user = await _context.Doctors.FirstOrDefaultAsync(u => u.Email == request.Email);
            if (user != null)
            { 
                response.DoctorAdded = false;
                response.Message = "Doctor Already Registered";
                return response;
            }

            var docId = _generateId.GenerateDoctorId();
            var doc = new Doctors
            {
                DoctorId = docId,
                DoctorName = request.DoctorName,
                Email = request.Email,
                DeptId = request.DeptId,
                Address = request.Address,
                PhoneNumber = request.PhoneNumber,
                ConsultFee = request.ConsultFee
            };

            _context.Doctors.Add(doc);
            await _context.SaveChangesAsync();
            return new AddDoctorResponse
            {
                DoctorAdded = true,
                Message = "Doctor Added Successfully"

            };   
        }

        public async Task<DeleteDoctorByIdResponse> DeleteDoctorAsync(DeleteDoctorByIdRequest request)
        {
            var exsists = await _context.Doctors.FirstOrDefaultAsync(d => d.DoctorId == request.DoctorId);
            if(exsists == null)
            {
                return new DeleteDoctorByIdResponse
                {
                    IsDeleted = false,
                    Msg = "Doctor Id Not Found"
                };
            }
            _context.Doctors.Remove(exsists);
            await _context.SaveChangesAsync();
            return new DeleteDoctorByIdResponse
            {
                IsDeleted = true,
                Msg = "Doctor Deleted Succesfully"
            };
        }
    }
}
