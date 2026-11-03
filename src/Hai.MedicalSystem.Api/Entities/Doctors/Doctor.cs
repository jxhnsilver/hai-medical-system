using Hai.MedicalSystem.Api.Entities.Patients;

namespace Hai.MedicalSystem.Api.Entities.Doctors
{
    public sealed class Doctor
    {
        public Guid Id { get; set; }
        public string LastName { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string? Patronymic { get; set; }

        // Статический справочник через enum (без отдельной таблицы по ТЗ)
        public Specialization Specialization { get; set; }

        public string CabinetNumber { get; set; } = string.Empty;
        public DoctorStatus Status { get; set; } = DoctorStatus.Active;

        public string Phone { get; set; } = string.Empty;
        public string? Email { get; set; }

        public List<Patient> Patients { get; set; } = new();
    }
}
