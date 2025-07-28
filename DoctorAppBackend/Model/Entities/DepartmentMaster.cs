using System.ComponentModel.DataAnnotations;

namespace DoctorAppBackend.Model.Entities
{
    public class DepartmentMaster
    {
        [Key]
        public string? DeptId { get; set; }
        public string? DeptName { get; set; }
    }
}
