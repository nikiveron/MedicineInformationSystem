using MedicalInformationSystem.ApiService.Models;
using MedicalInformationSystem.ApiService.Services;
using Microsoft.AspNetCore.Mvc;
using System.IO;

namespace MedicalInformationSystem.ApiService.Controllers;

[Route("doctors")]
[ApiController]
public class DoctorController(IDoctorRepository doctorsRepository, ILogger<DoctorController> logger) : Controller
{
    [HttpGet]
    public async Task<ActionResult<List<DoctorEntity>>> Get([FromQuery] DoctorFilter infoFilter, CancellationToken cancellationToken)
    {
        try
        {
            var doctorsList = await doctorsRepository.Get(infoFilter, cancellationToken);
            logger.LogInformation($"GET request diseases list with {infoFilter}");
            return Ok(doctorsList);
        }
        catch (Exception ex)
        {
            logger.LogError($"internal server error: {ex.Message}");
            return StatusCode(500, $"Внутренняя ошибка сервера.");
        }
    }

    [HttpGet("{id}")]
    public async Task<ActionResult> Get([FromRoute] int id, CancellationToken cancellationToken)
    {
        try
        {
            var doctor = await doctorsRepository.Get(id, cancellationToken);

            if (doctor == null)
            {
                return NotFound();
            }

            logger.LogInformation($"GET request doctor/{id}");
            return Ok(doctor);
        }
        catch (Exception ex)
        {
            logger.LogError($"internal server error: {ex.Message}");
            return StatusCode(500, $"Внутренняя ошибка сервера.");
        }
    }
}

