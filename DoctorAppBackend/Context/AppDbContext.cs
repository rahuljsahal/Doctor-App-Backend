using DoctorAppBackend.Model.Entities;
using Microsoft.EntityFrameworkCore;

namespace DoctorAppBackend.Context
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {   
        }
        public DbSet<Patients> Patients { get; set; }
        public DbSet<Doctors> Doctors { get; set; }
        public DbSet<DepartmentMaster> Departments { get; set; }
        public DbSet<Consultations> Consultations { get; set; }


        
    }
}
