namespace MedicalInformationSystem.ApiService;

public record DoctorFilter
{
    public int DoctorId { get; set; }
    public string Surname { get; set; }
    public string Name { get; set; }
    public string Patronymic { get; set; }
    public string Specialization { get; set; }
    public string LicenseNumber { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }
    public string? OfficeNumber { get; set; }
    public string? WorkSchedule { get; set; }

    public DoctorFilter(int doctorId, string surname, string name, string patronymic, string specialization, string licenseNumber, string phone, string email, string? officeNumber, string? workSchedule)
    {
        DoctorId = doctorId;
        Surname = surname;
        Name = name;
        Patronymic = patronymic;
        Specialization = specialization;
        LicenseNumber = licenseNumber;
        Phone = phone;
        Email = email;
        OfficeNumber = officeNumber;
        WorkSchedule = workSchedule;
    }

    public DoctorFilter()
    {
        DoctorId = -1;
        Surname = "";
        Name = "";
        Patronymic = "";
        Specialization = "";
        LicenseNumber = "";
        Phone = "";
        Email = "";
        OfficeNumber = "";
        WorkSchedule = "";
    }
}
