using Hai.MedicalSystem.Api.Dtos;
using Hai.MedicalSystem.Api.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Hai.MedicalSystem.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public sealed class DoctorsController(IDoctorService doctorService) : ControllerBase
    {
        /// <summary>
        /// Получить врачей, сгруппированных по специализациям.
        /// </summary>
        /// <param name="ct">Токен отмены запроса.</param>
        /// <response code="200">Список врачей успешно получен.</response>
        [HttpGet("grouped-by-specialization")]
        [ProducesResponseType(typeof(IReadOnlyList<DoctorsBySpecializationDto>), StatusCodes.Status200OK)]
        public async Task<ActionResult<IReadOnlyList<DoctorsBySpecializationDto>>> GetGroupedBySpecialization(CancellationToken ct)
        {
            return Ok(await doctorService.GetGroupedBySpecializationAsync(ct));
        }
    }
}
