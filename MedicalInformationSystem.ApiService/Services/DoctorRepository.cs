using MedicalInformationSystem.ApiService.Models;
using Microsoft.EntityFrameworkCore;

namespace MedicalInformationSystem.ApiService.Services;

public interface IDoctorRepository
{
    Task<List<DoctorEntity>> Get(CancellationToken cancellationToken);
    Task<DoctorEntity?> Get(int doctorId, CancellationToken cancellationToken);
}

internal class DoctorRepository(AppDbContext context) : IDoctorRepository
{
    public async Task<List<DoctorEntity>> Get(CancellationToken cancellationToken)
    {
        var result = await context.Doctors.ToListAsync(cancellationToken);
        return result;
    }

    public async Task<DoctorEntity?> Get(int doctorId, CancellationToken cancellationToken)
    {
        var result = await context.Doctors.FindAsync(doctorId, cancellationToken);
        return result;
    }
}

