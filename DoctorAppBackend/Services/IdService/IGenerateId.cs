namespace DoctorAppBackend.Services.IdService
{
    public interface IGenerateId
    {
        string GeneratePatientId();
        string GenerateHospitalId();
        string GenerateDoctorId();
        string GenrateDeptId();
    }
}
