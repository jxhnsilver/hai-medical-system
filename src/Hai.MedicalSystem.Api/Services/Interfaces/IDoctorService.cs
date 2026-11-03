using Hai.MedicalSystem.Api.Dtos;
using Hai.MedicalSystem.Api.Entities.Doctors;

namespace Hai.MedicalSystem.Api.Services.Interfaces
{
    public interface IDoctorService
    {
        Task<IReadOnlyList<DoctorsBySpecializationDto>> GetGroupedBySpecializationAsync(CancellationToken ct);
    }
}
