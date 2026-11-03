namespace Hai.MedicalSystem.Api.Dtos
{
    /// <summary>
    /// DTO модели болезни.
    /// </summary>
    /// <param name="Id">Идентификатор болезни.</param>
    /// <param name="Name">Название болезни.</param>
    /// <param name="Code">Код болезни (например МКБ).</param>
    /// <param name="Description">Описание болезни.</param>
    public record DiseaseDto(
        Guid Id,
        string Name,
        string Code,
        string Description
        );
}
