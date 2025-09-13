using MedicalInformationSystem.ApiService.Models;
using MedicalInformationSystem.ApiService.Services;
using Microsoft.AspNetCore.Mvc;

namespace MedicalInformationSystem.ApiService.Controllers;

[Route("doctors")]
public class DoctorController(IDoctorRepository doctorsRepository) : Controller
{
    [HttpGet("getDoctors")]
    public async Task<ActionResult<List<DoctorEntity>>> Get(CancellationToken cancellationToken)
    {
        try
        {
            var doctorsList = await doctorsRepository.Get(cancellationToken);
            return Ok(doctorsList);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Внутренняя ошибка сервера: {ex.Message}");
        }
    }

    [HttpGet("getDoctor/{id}")]
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

