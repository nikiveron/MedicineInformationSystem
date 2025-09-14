namespace MedicalInformationSystem.Web;

public record Patient(int id, string Surname, string Name, DateTimeOffset DateOfBirth, string Gender, string Phone);

public class PatientsApiClient(HttpClient httpClient)
{
    public async Task<Patient[]> GetPatientsAsync(int maxItems = 10, CancellationToken cancellationToken = default)
    {
        List<Patient>? patients = null;

        await foreach (var patient in httpClient.GetFromJsonAsAsyncEnumerable<Patient>("/patients", cancellationToken))
        {
            if (patients?.Count >= maxItems)
            {
                break;
            }
            if (patient is not null)
            {
                patients ??= [];
                patients.Add(patient);
            }
        }

        return patients?.ToArray() ?? [];
    }
}
