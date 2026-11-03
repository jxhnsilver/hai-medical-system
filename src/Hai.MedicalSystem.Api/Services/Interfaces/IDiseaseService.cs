using Hai.MedicalSystem.Api.Dtos;

namespace Hai.MedicalSystem.Api.Services.Interfaces
{
    public interface IDiseaseService
    {
        Task<IReadOnlyList<DiseaseDto>> GetAllAsync(CancellationToken ct);
    }
}
