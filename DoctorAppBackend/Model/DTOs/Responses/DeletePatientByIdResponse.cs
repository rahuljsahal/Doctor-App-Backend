namespace DoctorAppBackend.Model.DTOs.Responses
{
    public class DeletePatientByIdResponse
    {
        public bool IsDeleted { get; set; }
        public string? Msg { get; set; }
    }
}
