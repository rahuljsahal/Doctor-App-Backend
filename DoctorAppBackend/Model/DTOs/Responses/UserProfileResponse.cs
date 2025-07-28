namespace DoctorAppBackend.Model.DTOs.Responses
{
    public class UserProfileResponse
    {
        public string? PatientId { get; set; }
        public string? PatientName { get; set; }
        public string? Email { get; set; }
        public DateTime Dob { get; set; }
        public string? Phno { get; set; }
    }
}
