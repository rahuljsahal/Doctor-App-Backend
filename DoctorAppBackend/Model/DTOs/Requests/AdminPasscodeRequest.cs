using System.ComponentModel.DataAnnotations;

namespace DoctorAppBackend.Model.DTOs.Requests
{
    public class AdminPasscodeRequest
    {
        [Required]
        public string? Passcode {get; set;}
    }
}
