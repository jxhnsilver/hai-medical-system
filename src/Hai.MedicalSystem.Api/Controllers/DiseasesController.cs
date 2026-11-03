using Hai.MedicalSystem.Api.Dtos;
using Hai.MedicalSystem.Api.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Hai.MedicalSystem.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public sealed class DiseasesController(IDiseaseService diseaseService) : ControllerBase
    {
        /// <summary>
        /// Получить общий список болезней.
        /// </summary>
        /// <param name="ct">Токен отмены запроса.</param>
        /// <response code="200">Список болезней успешно получен.</response>
        [HttpGet]
        [ProducesResponseType(typeof(IReadOnlyList<DiseaseDto>), StatusCodes.Status200OK)]
        public async Task<ActionResult<IReadOnlyList<DiseaseDto>>> GetAll(CancellationToken ct)
        {
            return Ok(await diseaseService.GetAllAsync(ct));
        }
    }
}
