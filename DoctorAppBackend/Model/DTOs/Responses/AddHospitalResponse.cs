namespace DoctorAppBackend.Model.DTOs.Responses
{
    public class AddHospitalResponse
    {
        public bool IsSuccess { get; set; }
        public string? Message { get; set; }
        public string? HospitalCode { get; set; }
    }
}
