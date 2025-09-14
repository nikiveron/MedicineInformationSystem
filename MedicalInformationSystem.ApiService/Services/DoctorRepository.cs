using MedicalInformationSystem.ApiService.Models;
using Microsoft.EntityFrameworkCore;

namespace MedicalInformationSystem.ApiService.Services;

public interface IDoctorRepository
{
    Task<List<DoctorEntity>> Get(DoctorFilter infoFilter, CancellationToken cancellationToken);
    Task<DoctorEntity?> Get(int doctorId, CancellationToken cancellationToken);
}

internal class DoctorRepository(AppDbContext context) : IDoctorRepository
{
    public async Task<List<DoctorEntity>> Get(DoctorFilter infoFilter, CancellationToken cancellationToken)
    {
        var result = await context.Doctors
            .Where(d => d.Specialization.Contains(infoFilter.Specialization))   // filters 
                     .ToListAsync(cancellationToken);
        return result;
    }

    public async Task<DoctorEntity?> Get(int doctorId, CancellationToken cancellationToken)
    {
        var result = await context.Doctors.FindAsync(doctorId, cancellationToken);
        return result;
    }
}

