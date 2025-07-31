namespace DoctorAppBackend.Services.IdService
{
    public class GenerateId : IGenerateId
    {
        public string GeneratePatientId()
        {
            return "PA-" + Guid.NewGuid().ToString("N")[..4].ToUpper();
        }

        public string GenerateDoctorId()
        {
            return "DO-" + Guid.NewGuid().ToString("N")[..5].ToUpper();
        }

        public string GenrateDeptId()
        {
            return "DT-" + Guid.NewGuid().ToString("N")[..5].ToUpper();
            
        }
        public string GenerateConsultId()
        {
            return "CT-" + Guid.NewGuid().ToString("N")[..5].ToUpper();
        }
    }
}
