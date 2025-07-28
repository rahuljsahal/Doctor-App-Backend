using System.ComponentModel.DataAnnotations;

namespace DoctorAppBackend.Model.DTOs.Requests
{
    public class SignUpRequest
    {
        public string? PatientId { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        [EmailAddress]
        public string? Email { get; set; }
        [Required]
        public DateTime DOB { get; set; }
        [Required]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "Phone number must be exactly 10 digits.")]
        public string? PhoneNo { get; set; }
        [Required]
        public string? Pwd{ get; set; }
        [Required]
        [Compare("Pwd", ErrorMessage ="Password Must Match")]
        public string? ConfirmPwd { get; set; }

        public DateTime DOR { get; set; } = DateTime.Now;
    }
}
