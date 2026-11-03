using Hai.MedicalSystem.Api.Data;
using Hai.MedicalSystem.Api.Dtos;
using Hai.MedicalSystem.Api.Entities.Doctors;
using Hai.MedicalSystem.Api.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;

namespace Hai.MedicalSystem.Api.Services.Implementations
{
    public sealed class DoctorService(
        ApplicationDbContext dbContext,
        ILogger<DoctorService> logger) : IDoctorService
    {
        public async Task<IReadOnlyList<DoctorsBySpecializationDto>> GetGroupedBySpecializationAsync(CancellationToken ct)
        {
            logger.LogDebug("Loading doctors grouped by specialization");

            var doctors = await dbContext.Doctors
                .AsNoTracking()
                .Select(d => new DoctorDto(
                    d.Id,
                    d.FirstName,
                    d.LastName,
                    d.Patronymic,
                    d.Specialization,
                    d.CabinetNumber,
                    d.Status,
                    d.Phone,
                    d.Email))
                .ToListAsync(ct);

            var grouped = doctors
                .GroupBy(d => d.Specialization)
                .OrderBy(g => g.Key)
                .Select(g => new DoctorsBySpecializationDto(
                    g.Key,
                    g.OrderBy(d => d.LastName)
                     .ThenBy(d => d.FirstName)
                     .ToList()
                    )).ToList();

            logger.LogDebug("Loaded {GroupCount} specialization groups", grouped.Count);
            return grouped;
        }
    }
}
