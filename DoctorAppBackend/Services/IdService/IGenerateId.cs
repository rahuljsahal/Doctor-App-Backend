namespace DoctorAppBackend.Services.IdService
{
    public interface IGenerateId
    {
        string GeneratePatientId();
        string GenerateDoctorId();
        string GenrateDeptId();
        string GenerateConsultId();
    }
}
