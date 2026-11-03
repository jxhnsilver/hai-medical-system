using Hai.MedicalSystem.Api.Dtos;

namespace Hai.MedicalSystem.Api.Services.Interfaces
{
    public interface IPatientService
    {
        Task<PatientDto> GetByIdAsync(Guid id, CancellationToken ct);
        Task<IReadOnlyList<PatientDto>> GetAllAsync(CancellationToken ct);
    }
}
