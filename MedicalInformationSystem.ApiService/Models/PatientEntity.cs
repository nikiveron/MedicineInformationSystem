using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedicalInformationSystem.ApiService.Models;

[Table("patient")]
public class PatientEntity
{
    [Key]
    [Column("patient_id")]
    public int PatientId { get; set; }

    [Required]
    [Column("surname")]
    public required string Surname { get; set; }

    [Required]
    [Column("name")]
    public required string Name { get; set; }

    [Required]
    [Column("patronymic")]
    public required string Patronymic { get; set; }

    [Required]
    [Column("date_of_birth")]
    public DateTimeOffset DateOfBirth { get; set; }

    [Required]
    [Column("gender")]
    public required string Gender { get; set; }

    [Required]
    [Column("phone")]
    public required string Phone { get; set; }

    [Required]
    [Column("policy_number")]
    public required int PolicyNumber { get; set; }

    [Required]
    [Column("created_at")]
    public DateTimeOffset? CreatedAt { get; set; }

    [Required]
    [Column("updated_at")]
    public DateTimeOffset? UpdatedAt { get; set; }

    [Column("deleted_at")]
    public DateTimeOffset? DeletedAt { get; set; }

    public List<AppointmentEntity> Appointments { get; set; } = new List<AppointmentEntity>();
}
