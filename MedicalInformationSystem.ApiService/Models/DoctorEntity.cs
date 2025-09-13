using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedicalInformationSystem.ApiService.Models;

[Table("doctor")]
public class DoctorEntity
{
    [Key]
    [Column("doctor_id")]
    public int DoctorId { get; set; }

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
    [Column("specialization")]
    public required string Specialization { get; set; }

    [Required]
    [Column("license_number")]
    public required string LicenseNumber { get; set; }

    [Required]
    [Column("phone")]
    public required string Phone { get; set; }

    [Required]
    [Column("email")]
    public required string Email { get; set; }

    [Column("office_number")]
    public string? OfficeNumber { get; set; }

    [Column("work_schedule")]
    public string? WorkSchedule { get; set; }

    [Required]
    [Column("created_at")]
    public DateTimeOffset? CreatedAt { get; set; }

    [Required]
    [Column("updated_at")]
    public DateTimeOffset? UpdatedAt { get; set; }

    [Column("deleted_at")]
    public DateTimeOffset? DeletedAt { get; set; }
}
