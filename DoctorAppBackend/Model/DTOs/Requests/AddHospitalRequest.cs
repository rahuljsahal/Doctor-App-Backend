using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace DoctorAppBackend.Model.DTOs.Requests
{
    public class AddHospitalRequest
    {
        [Required]
        [JsonPropertyName("name")]
        
        public string? HospitalName { get; set; }
    }
}
