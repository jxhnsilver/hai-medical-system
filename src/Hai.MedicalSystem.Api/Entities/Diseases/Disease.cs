using Hai.MedicalSystem.Api.Entities.Patients;

namespace Hai.MedicalSystem.Api.Entities.Diseases
{
    public sealed class Disease
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }

        public List<Patient> Patients { get; set; } = new();
    }
}
