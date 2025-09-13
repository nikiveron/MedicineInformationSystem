using MedicalInformationSystem.ApiService.Models;
using Microsoft.AspNetCore.Mvc;
using MedicalInformationSystem.ApiService.Services;

namespace MedicalInformationSystem.ApiService.Controllers;

[Route("patients")]
public class PatientController(IPatientRepository patientRepository) : Controller
{
    [HttpGet("getPatients")]
    public async Task<ActionResult<List<PatientEntity>>> Get(CancellationToken cancellationToken)
    {
        try
        {
            var patientsList = await patientRepository.Get(cancellationToken);
            return Ok(patientsList);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Внутренняя ошибка сервера: {ex.Message}");
        }
    }

    [HttpGet("getPatient/{id}")]
    public async Task<ActionResult> Get([FromRoute] int id, CancellationToken cancellationToken)
    {
        try
        {
            var agent = await patientRepository.Get(id, cancellationToken);

            if (agent == null)
            {
                return NotFound();
            }

            return Ok(agent);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Внутренняя ошибка сервера: {ex.Message}");
        }
    }
}
