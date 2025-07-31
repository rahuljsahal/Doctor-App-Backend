namespace DoctorAppBackend.Model.DTOs.Requests
{
    public class ConsultDoctorRequest
    {
        public string? ConsultId { get; set; }
        public long Aadhar { get; set; }
        public string? Name { get; set; }
        public string? ConsultingDept { get; set; }
        public string? ConsultingDoctor { get; set; }
        public DateTime Date { get; set; }

        public double ConsultFee { get; set; }

    }
}
