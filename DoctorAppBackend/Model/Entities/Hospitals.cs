using System.ComponentModel.DataAnnotations;

namespace DoctorAppBackend.Model.Entities
{
    public class Hospitals
    {
        [Key]
        public string? HospitalCode { get; set; }
        public string? HospitalName { get; set; }
    }
}
