using MedicalInformationSystem.Web.Components.Pages;

namespace MedicalInformationSystem;

public record Disease(int id, string Name, string IcdCode, string? Description, string? Symptoms, string? Treatment, bool IsChronic);

public class DiseasesApiClient(HttpClient httpClient)
{
    public async Task<Disease[]> GetDiseasesAsync(int maxItems = 10, CancellationToken cancellationToken = default)
    {
        List<Disease>? diseases = null;

        await foreach (var disease in httpClient.GetFromJsonAsAsyncEnumerable<Disease>("/diseases", cancellationToken))
        {
            if (diseases?.Count >= maxItems)
            {
                break;
            }
            if (disease is not null)
            {
                diseases ??= [];
                diseases.Add(disease);
            }
        }

        return diseases?.ToArray() ?? [];
    }

    public async Task<Disease?> GetDiseaseAsync(int id, CancellationToken cancellationToken = default)
    {
        var queryResult = httpClient.GetFromJsonAsAsyncEnumerable<Disease>($"/diseases/{id}", cancellationToken);
        Disease? result = null;
        await foreach (var disease in queryResult)
        {
            if (disease.id == id)
            {
                result = disease;
                break;
            }
        }
        return result;
    }
}
