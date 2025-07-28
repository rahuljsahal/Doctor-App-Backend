using System.ComponentModel.DataAnnotations;

namespace DoctorAppBackend.Model.Entities
{
    public class Doctors
    {
        [Key]
        public string? DoctorId { get; set; }
        public string? Email { get; set; }
        public string? DoctorName { get; set; }
        public string? DeptId { get; set; }
        public string? Address { get; set; }
        public string? HCode { get; set; }
        public string? PhoneNumber { get; set; }

    }
}
