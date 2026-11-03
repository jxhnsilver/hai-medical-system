using Hai.MedicalSystem.Api.Entities.Patients;

namespace Hai.MedicalSystem.Api.Dtos
{
    /// <summary>
    /// DTO модели пациента.
    /// </summary>
    /// <param name="Id">Идентификатор пациента.</param>
    /// <param name="FirstName">Имя.</param>
    /// <param name="LastName">Фамилия.</param>
    /// <param name="Patronymic">Отчество.</param>
    /// <param name="Gender">Пол.</param>
    /// <param name="BirthDate">Дата рождения.</param>
    /// <param name="Phone">Телефон.</param>
    /// <param name="Email">Email.</param>
    /// <param name="PolicyNumber">Номер полиса.</param>
    /// <param name="CurrentDoctorId">Текущий лечащий врач.</param>
    /// <param name="Diseases">Список болезней пациента.</param>
    public record PatientDto(
        Guid Id,
        string FirstName,
        string LastName,
        string? Patronymic,
        Gender Gender,
        DateOnly BirthDate,
        string Phone,
        string? Email,
        string PolicyNumber,
        Guid? CurrentDoctorId,
        IReadOnlyList<DiseaseDto> Diseases
        );
}
