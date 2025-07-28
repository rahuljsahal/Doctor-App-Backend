using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DoctorAppBackend.Model.DTOs.Requests
{
    public class SignInRequest
    {
        [Required]
        [EmailAddress]
        public string? Email { get; set; }
        [Required]
        public string? Pwd { get; set; }
    }
}
