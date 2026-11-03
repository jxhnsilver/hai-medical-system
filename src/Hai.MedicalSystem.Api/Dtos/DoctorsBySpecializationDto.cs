using Hai.MedicalSystem.Api.Entities.Doctors;

namespace Hai.MedicalSystem.Api.Dtos
{
    /// <summary>
    /// DTO для группировки врачей по специализации.
    /// </summary>
    /// <param name="Specialization">Специализация врачей.</param>
    /// <param name="Doctors">Список врачей данной специализации.</param>
    public record DoctorsBySpecializationDto(
        Specialization Specialization,
        IReadOnlyList<DoctorDto> Doctors
    );
}
