using MedicalInformationSystem.ApiService.Models;
using Microsoft.AspNetCore.Mvc;
using MedicalInformationSystem.ApiService.Services;

namespace MedicalInformationSystem.ApiService.Controllers;

[Route("patients")]
public class PatientController(IPatientRepository patientRepository, ILogger<PatientController> logger) : Controller
{
    [HttpGet]
    public async Task<ActionResult<List<PatientEntity>>> Get(CancellationToken cancellationToken)
    {
        try
        {
            var patientsList = await patientRepository.Get(cancellationToken);
            logger.LogInformation($"GET request patient list");
            return Ok(patientsList);
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
            var patient = await patientRepository.Get(id, cancellationToken);

            if (patient == null)
            {
                return NotFound();
            }

            logger.LogInformation($"GET request patient/{id}");
            return Ok(patient);
        }
        catch (Exception ex)
        {
            logger.LogError($"internal server error: {ex.Message}");
            return StatusCode(500, $"Внутренняя ошибка сервера: {ex.Message}");
        }
    }
}
