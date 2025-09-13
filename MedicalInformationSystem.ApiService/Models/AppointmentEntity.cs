using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedicalInformationSystem.ApiService.Models;

[Table("appointment")]
public class AppointmentEntity
{
    [Key]
    [Column("appointment_id")]
    public int AppointmentId { get; set; }

    [Required]
    [Column("patient_id")]
    public int PatientId { get; set; }

    [Required]
    [Column("doctor_id")]
    public int DoctorId { get; set; }

    [Column("disease_id")]
    public int? DiseaseId { get; set; }

    [Required]
    [Column("visit_date")]
    public DateTimeOffset VisitDate { get; set; }

    [Column("complaints")]
    public string? Complaints { get; set; }

    [Column("diagnosis")]
    public string? Diagnosis { get; set; }

    [Column("prescriptions")]
    public string? Prescriptions { get; set; }

    [Column("recommendations")]
    public string? Recommendations { get; set; }

    [Column("follow_up_date")]
    public DateTimeOffset? FollowUpDate { get; set; }

    [Required]
    [Column("status")]
    public required string Status { get; set; }

    [Required]
    [Column("created_at")]
    public DateTimeOffset? CreatedAt { get; set; }

    [Required]
    [Column("updated_at")]
    public DateTimeOffset? UpdatedAt { get; set; }

    [Column("deleted_at")]
    public DateTimeOffset? DeletedAt { get; set; }
}
