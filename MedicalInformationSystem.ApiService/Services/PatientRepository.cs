using MedicalInformationSystem.ApiService.Models;
using Microsoft.EntityFrameworkCore;

namespace MedicalInformationSystem.ApiService.Services;

public interface IPatientRepository
{
    Task<List<PatientEntity>> Get(CancellationToken cancellationToken);
    Task<PatientEntity?> Get(int patientId, CancellationToken cancellationToken);
}

internal class PatientRepository(AppDbContext context) : IPatientRepository
{
    public async Task<List<PatientEntity>> Get(CancellationToken cancellationToken)
    {
        var result = await context.Patients.ToListAsync(cancellationToken);
        return result;
    }

    public async Task<PatientEntity?> Get(int patientId, CancellationToken cancellationToken)
    {
        var result = await context.Patients.FindAsync(patientId, cancellationToken);
        return result;
    }
}
