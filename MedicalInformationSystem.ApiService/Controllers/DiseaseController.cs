using MedicalInformationSystem.ApiService.Models;
using MedicalInformationSystem.ApiService.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MedicalInformationSystem.ApiService.Controllers;

[Route("diseases")]
public class DiseaseController(IDiseaseRepository diseasesRepository, ILogger<DiseaseController> logger) : Controller
{
    [HttpGet]
    public async Task<ActionResult<List<DoctorEntity>>> Get(CancellationToken cancellationToken)
    {
        try
        {
            var diseasesList = await diseasesRepository.Get(cancellationToken);
            logger.LogInformation($"GET request diseases list");
            return Ok(diseasesList);
        }
        catch (Exception ex)
        {
            logger.LogError($"internal server error: {ex.Message}");
            return StatusCode(500, $"Внутренняя ошибка сервера: {ex.Message}");
        }
    }

    [HttpGet("{id}")]
    public async Task<ActionResult> Get([FromRoute] int id, CancellationToken cancellationToken)
    {
        try
        {
            var disease = await diseasesRepository.Get(id, cancellationToken);

            if (disease == null)
            {
                return NotFound();
            }

            logger.LogInformation($"GET request disease/{id}");
            return Ok(disease);
        }
        catch (Exception ex)
        {
            logger.LogError($"internal server error: {ex.Message}");
            return StatusCode(500, $"Внутренняя ошибка сервера: {ex.Message}");
        }
    }
}

