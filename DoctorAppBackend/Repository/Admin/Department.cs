using DoctorAppBackend.Context;
using DoctorAppBackend.Model.DTOs.Requests;
using DoctorAppBackend.Model.DTOs.Responses;
using DoctorAppBackend.Model.Entities;
using DoctorAppBackend.Services.IdService;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace DoctorAppBackend.Repository.Admin
{
    public class Department : IDepartment
    {
        private readonly AppDbContext _context;
        private readonly IGenerateId _deptId;

        public Department(AppDbContext context, IGenerateId deptid)
        {
            _context = context;
            _deptId = deptid;
            
        }
        public async Task<AddDepartmentResponse> AddDept(AddDepartmentRequest request)
        {
            var exists = await _context.Departments.FirstOrDefaultAsync(d => d.DeptName == request.DeptName);
            if(exists != null)
            {
                return new AddDepartmentResponse
                {
                    DeptAdded = false,
                    Message = "Department Already Exists"
                };
            }
            string deptId = _deptId.GenrateDeptId();
            var Dept = new DepartmentMaster
            {
                DeptId = deptId,
                DeptName = request.DeptName
            };
            _context.Add(Dept);
            await _context.SaveChangesAsync();

            return new AddDepartmentResponse
            {
                DeptAdded = true,
                Message = "Department Added Successfully"
            };
            
        }
    }
}
