namespace DoctorAppBackend.Model.DTOs.Requests
{
    public class AddDoctorRequest
    {
        public string? DoctorName { get; set; }
        public string? Email { get; set; }
        public string? DeptId { get; set; }
        public string? Address { get; set; }
        public string? HCode { get; set; }
        public string? PhoneNumber { get; set; }
    }
}
