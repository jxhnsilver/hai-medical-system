using Hai.MedicalSystem.Api.Entities.Patients;

namespace Hai.MedicalSystem.Api.Entities.Diseases
{
    public sealed class Disease
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Code { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        public List<Patient> Patients { get; set; } = new();
    }
}
