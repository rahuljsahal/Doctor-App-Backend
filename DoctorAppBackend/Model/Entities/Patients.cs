using System.ComponentModel.DataAnnotations;

namespace DoctorAppBackend.Model.Entities
{
    public class Patients
    {
        [Key]
        public string? PatientId { get; set; }

        public string? Name { get; set; }

        public string? Email { get; set; }

        public DateTime DOB { get; set; }

        public string? PhoneNo { get; set; }

        public string? Pwd { get; set; }

        public DateTime DOR { get; set; }
    }
}
