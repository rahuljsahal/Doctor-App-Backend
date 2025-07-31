using System.ComponentModel.DataAnnotations;

namespace DoctorAppBackend.Model.Entities
{
    public class Consultations
    {
        [Key]
        public string? ConsultId { get; set; }
        public long Aadhar { get; set; }
        public string? Name { get; set; }
        public string? ConsultingDept { get; set; }
        public string? ConsultingDoctor { get; set; }
        public DateTime Date { get; set; }
        public double ConsultFee { get; set; }
    }
}
