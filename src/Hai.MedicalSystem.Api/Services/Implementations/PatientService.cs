using Hai.MedicalSystem.Api.Common.Exceptions;
using Hai.MedicalSystem.Api.Data;
using Hai.MedicalSystem.Api.Dtos;
using Hai.MedicalSystem.Api.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Hai.MedicalSystem.Api.Services.Implementations
{
    public class PatientService(
        ApplicationDbContext dbContext,
        ILogger<PatientService> logger) : IPatientService
    {
        public async Task<IReadOnlyList<PatientDto>> GetAllAsync(CancellationToken ct)
        {
            logger.LogDebug("Loading all patients");

            var patients = await dbContext.Patients
                .AsNoTracking()
                .Select(p => new PatientDto(
                    Id: p.Id,
                    FirstName: p.FirstName,
                    LastName: p.LastName,
                    Patronymic: p.Patronymic,
                    Gender: p.Gender,
                    BirthDate: p.BirthDate,
                    Phone: p.Phone,
                    Email: p.Email,
                    PolicyNumber: p.PolicyNumber,
                    CurrentDoctorId: p.CurrentDoctorId,
                    Diseases: p.Diseases
                        .Select(d => new DiseaseDto(
                            Id: d.Id,
                            Name: d.Name,
                            Code: d.Code,
                            Description: d.Description))
                        .ToList()))
                .ToListAsync(ct);

            logger.LogDebug("Loaded {Count} patients", patients.Count);
            return patients;
        }

        public async Task<PatientDto> GetByIdAsync(Guid id, CancellationToken ct)
        {
            logger.LogDebug("Loading patient by id {PatientId}", id);

            var patient = await dbContext.Patients
                .AsNoTracking()
                .Where(p => p.Id == id)
                .Select(p => new PatientDto(
                    Id: p.Id,
                    FirstName: p.FirstName,
                    LastName: p.LastName,
                    Patronymic: p.Patronymic,
                    Gender: p.Gender,
                    BirthDate: p.BirthDate,
                    Phone: p.Phone,
                    Email: p.Email,
                    PolicyNumber: p.PolicyNumber,
                    CurrentDoctorId: p.CurrentDoctorId,
                    Diseases: p.Diseases
                        .Select(d => new DiseaseDto(
                            Id: d.Id,
                            Name: d.Name,
                            Code: d.Code,
                            Description: d.Description))
                        .ToList()))
                .FirstOrDefaultAsync(ct);

            if (patient is null)
            {
                logger.LogInformation("Patient with id {PatientId} not found", id);
                throw new NotFoundException($"Patient with id '{id}' not found.");
            }

            return patient;
        }
    }
}
