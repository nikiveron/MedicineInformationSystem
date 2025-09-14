using MedicalInformationSystem.ApiService.Models;
using MedicalInformationSystem.ApiService.Services;
using Microsoft.AspNetCore.Mvc;

namespace MedicalInformationSystem.ApiService.Controllers;

[Route("doctors")]
[ApiController]
public class DoctorController(IDoctorRepository doctorsRepository) : Controller
{
    [HttpGet]
    public async Task<ActionResult<List<DoctorEntity>>> Get([FromQuery] DoctorFilter infoFilter, CancellationToken cancellationToken)
    {
        try
        {
            var doctorsList = await doctorsRepository.Get(infoFilter, cancellationToken);
            return Ok(doctorsList);
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
            var doctor = await doctorsRepository.Get(id, cancellationToken);

            if (doctor == null)
            {
                return NotFound();
            }

            return Ok(doctor);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Внутренняя ошибка сервера: {ex.Message}");
        }
    }
}

