using Hai.MedicalSystem.Api.Data;
using Hai.MedicalSystem.Api.Dtos;
using Hai.MedicalSystem.Api.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Hai.MedicalSystem.Api.Services.Implementations
{
    public sealed class DiseaseService(
        ApplicationDbContext dbContext,
        ILogger<DiseaseService> logger) : IDiseaseService
    {
        public async Task<IReadOnlyList<DiseaseDto>> GetAllAsync(CancellationToken ct)
        {
            logger.LogDebug("Loading diseases list");

            var diseases = await dbContext.Diseases
                .AsNoTracking()
                .Select(d => new DiseaseDto(
                    d.Id,
                    d.Name,
                    d.Code,
                    d.Description))
                .ToListAsync(ct);

            logger.LogDebug("Loaded {Count} diseases", diseases.Count);
            return diseases;
        }
    }
}
