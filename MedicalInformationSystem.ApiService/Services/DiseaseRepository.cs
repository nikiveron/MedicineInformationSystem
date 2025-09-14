using MedicalInformationSystem.ApiService.Models;
using Microsoft.EntityFrameworkCore;

namespace MedicalInformationSystem.ApiService.Services;

public interface IDiseaseRepository
{
    Task<List<DiseaseEntity>> Get(CancellationToken cancellationToken);
    Task<DiseaseEntity?> Get(int doctorId, CancellationToken cancellationToken);
}

internal class DiseaseRepository(AppDbContext context) : IDiseaseRepository
{
    public async Task<List<DiseaseEntity>> Get(CancellationToken cancellationToken)
    {
        var result = await context.Diseases.ToListAsync(cancellationToken);
        return result;
    }

    public async Task<DiseaseEntity?> Get(int diseaseId, CancellationToken cancellationToken)
    {
        var result = await context.Diseases.FindAsync(diseaseId, cancellationToken);
        return result;
    }
}

