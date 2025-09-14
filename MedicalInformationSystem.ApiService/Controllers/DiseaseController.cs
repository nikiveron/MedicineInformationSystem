using MedicalInformationSystem.ApiService.Models;
using Microsoft.AspNetCore.Mvc;
using MedicalInformationSystem.ApiService.Services;

namespace MedicalInformationSystem.ApiService.Controllers;

[Route("diseases")]
public class DiseaseController(IDiseaseRepository diseasesRepository) : Controller
{
    [HttpGet]
    public async Task<ActionResult<List<DoctorEntity>>> Get(CancellationToken cancellationToken)
    {
        try
        {
            var diseasesList = await diseasesRepository.Get(cancellationToken);
            return Ok(diseasesList);
        }
        catch (Exception ex)
        {
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

            return Ok(disease);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Внутренняя ошибка сервера: {ex.Message}");
        }
    }
}

