using DoctorAppBackend.Context;
using DoctorAppBackend.Model.DTOs.Requests;
using DoctorAppBackend.Model.DTOs.Responses;
using DoctorAppBackend.Model.Entities;
using DoctorAppBackend.Services.IdService;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace DoctorAppBackend.Repository.Authenticaction
{
    public class Authentication : IAuthentication
    {
        private readonly AppDbContext _context;
        private readonly IGenerateId _generateId;
        public Authentication(AppDbContext context, IGenerateId generateId)
        {
            _context = context;
            _generateId = generateId;
            
        }
        public async Task<SignInResponse> SignIn(SignInRequest request)
        {
            SignInResponse response = new SignInResponse();
            var user = await _context.Patients.FirstOrDefaultAsync(user => user.Email == request.Email);
            if (user == null)
            {
                response.IsLogin = false;
                response.Msg = "Invalid Email";
            }
            else
            {
                var hasher = new PasswordHasher<SignInRequest>();
                var result = hasher.VerifyHashedPassword(request, user.Pwd, request.Pwd);

                if (result == PasswordVerificationResult.Success)
                {
                    response.IsLogin = true;
                    response.Msg = "Login Sucessful";
                }
                else
                {
                    response.IsLogin = false;
                    response.Msg = "Invalid Password";
                }
               

            }
            return response;
        }
        public async Task<SignUpResponse> SignUp(SignUpRequest request)
        {
            var response = new SignUpResponse();
            //checking for user exist or not
            var existingUser = await _context.Patients.FirstOrDefaultAsync(u => u.Email == request.Email);
            if(existingUser != null)
            {
                response.IsSuccess = false;
                response.Message = "User already exist";
                return response;
            }
            string patientId = _generateId.GeneratePatientId();
            var hasher = new PasswordHasher<SignUpRequest>();
            string hashedPass = hasher.HashPassword(request, request.Pwd);
            var patient = new Patients
            {
                PatientId = patientId,
                Name = request.Name,
                Email = request.Email,
                DOB = request.DOB,
                PhoneNo = request.PhoneNo,
                Pwd = hashedPass,
                DOR = request.DOR
            };

            _context.Patients.Add(patient);
            await _context.SaveChangesAsync();

            response.IsSuccess = true;
            response.Message = "User registered successfully";
            return response;
        }
    }
}
