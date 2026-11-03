using Hai.MedicalSystem.Api.Entities.Doctors;

namespace Hai.MedicalSystem.Api.Dtos
{
    /// <summary>
    /// DTO модели врача.
    /// </summary>
    /// <param name="Id">Идентификатор врача.</param>
    /// <param name="FirstName">Имя.</param>
    /// <param name="LastName">Фамилия.</param>
    /// <param name="Patronymic">Отчество.</param>
    /// <param name="Specialization">Специализация.</param>
    /// <param name="CabinetNumber">Номер кабинета.</param>
    /// <param name="Status">Статус врача.</param>
    /// <param name="Phone">Телефон.</param>
    /// <param name="Email">Email.</param>
    public record DoctorDto(
        Guid Id,
        string FirstName,
        string LastName,
        string? Patronymic,
        Specialization Specialization,
        string CabinetNumber,
        DoctorStatus Status,
        string Phone,
        string? Email
    );
}
