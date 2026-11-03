using Hai.MedicalSystem.Api.Dtos;
using Hai.MedicalSystem.Api.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Hai.MedicalSystem.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public sealed class PatientsController(IPatientService patientService) : ControllerBase
    {
        /// <summary>
        /// Получить список всех пациентов.
        /// </summary>
        /// <param name="ct">Токен отмены запроса.</param>
        /// <response code="200">Список пациентов успешно получен.</response>
        [HttpGet]
        [ProducesResponseType(typeof(IReadOnlyList<PatientDto>), StatusCodes.Status200OK)]
        public async Task<ActionResult<IReadOnlyList<PatientDto>>> GetAll(CancellationToken ct)
        {
            return Ok(await patientService.GetAllAsync(ct));
        }

        /// <summary>
        /// Получить пациента по идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор пациента.</param>
        /// <param name="ct">Токен отмены запроса.</param>
        /// <response code="200">Пациент найден.</response>
        /// <response code="404">Пациент не найден.</response>
        [HttpGet("{id:guid}")]
        [ProducesResponseType(typeof(PatientDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<PatientDto>> GetById(Guid id, CancellationToken ct)
        {
            return Ok(await patientService.GetByIdAsync(id, ct));
        }
    }
}
