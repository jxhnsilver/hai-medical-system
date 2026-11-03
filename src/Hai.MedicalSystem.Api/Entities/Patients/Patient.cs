using Hai.MedicalSystem.Api.Entities.Diseases;
using Hai.MedicalSystem.Api.Entities.Doctors;

namespace Hai.MedicalSystem.Api.Entities.Patients
{
    public sealed class Patient
    {
        public Guid Id { get; set; }
        public string LastName { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string? Patronymic { get; set; }
        public DateOnly BirthDate { get; set; }
        public Gender Gender { get; set; }
        public string Phone { get; set; } = string.Empty;
        public string? Email { get; set; }
        public string PolicyNumber { get; set; } = string.Empty;
        public Guid? CurrentDoctorId { get; set; }
        public Doctor? CurrentDoctor { get; set; }

        public List<Disease> Diseases { get; set; } = new();
    }
}
