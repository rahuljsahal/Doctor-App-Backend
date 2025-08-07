
using DoctorAppBackend.Context;
using DoctorAppBackend.Repository.Admin;
using DoctorAppBackend.Repository.Authenticaction;
using DoctorAppBackend.Repository.Doctor;
using DoctorAppBackend.Repository.UserRecords;
using DoctorAppBackend.Services.IdService;
using Microsoft.EntityFrameworkCore;

namespace DoctorAppBackend
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowFrontend", policy =>
                {
                    policy.WithOrigins("http://localhost:5173")
                          .AllowAnyHeader()
                          .AllowAnyMethod()
                          .AllowCredentials();
                });
            });

            builder.Services.AddAuthentication("Bearer").AddJwtBearer("Bearer", options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"])),
                    ValidIssuer = builder.Configuration["Jwt:Issuer"],
                    ValidAudience = builder.Configuration["Jwt:Audience"],
                    
                };
            });

            builder.Services.AddAuthorization();

            // DB Context
            builder.Services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("Connection")));

            // Dependency Injection - Custom Services
            builder.Services.AddScoped<IGenerateId, GenerateId>();
            builder.Services.AddScoped<IAuthentication, Authentication>();
            builder.Services.AddScoped<IAdmin, Admin>();
            builder.Services.AddScoped<IDoctor, Doctor>();
            builder.Services.AddScoped<IProfile, Profile>();
            builder.Services.AddScoped<IUpdateProfile, UpdateProfile>();
            builder.Services.AddScoped<IDepartment, Department>();
            builder.Services.AddScoped<IConsult, Consult>();
            builder.Services.AddControllers();
            
            // Swagger Setup
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseHttpsRedirection();
            app.UseCors("AllowFrontend");



            app.UseAuthorization();


            app.MapControllers();

            app.Run();

        }
    }
}
