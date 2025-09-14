namespace MedicalInformationSystem.Web;

public record Doctor(int id, string Surname, string Name, string Specialization, string Phone, string? OfficeNumber, string? WorkSchedule);

public class DoctorsApiClient(HttpClient httpClient)
{
    public async Task<Doctor[]> GetDoctorsAsync(int maxItems = 10, CancellationToken cancellationToken = default)
    {
        List<Doctor>? doctors = null;

        await foreach (var doctor in httpClient.GetFromJsonAsAsyncEnumerable<Doctor>("/doctors", cancellationToken))
        {
            if (doctors?.Count >= maxItems)
            {
                break;
            }
            if (doctor is not null)
            {
                doctors ??= [];
                doctors.Add(doctor);
            }
        }

        return doctors?.ToArray() ?? [];
    }

    public async Task<Doctor?> GetDoctorAsync(int id, CancellationToken cancellationToken = default)
    {
        var queryResult = httpClient.GetFromJsonAsAsyncEnumerable<Doctor>($"/doctors/{id}", cancellationToken);
        Doctor? result = null;
        await foreach (var doctor in queryResult)
        {
            if (doctor.id == id)
            {
                result = doctor;
                break;
            }
        }
        return result;
    }
}
