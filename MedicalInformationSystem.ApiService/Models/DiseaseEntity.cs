using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedicalInformationSystem.ApiService.Models;

[Table("disease")]
public class DiseaseEntity
{
    [Key]
    [Column("disease_id")]
    public int DiseaseId { get; set; }

    [Required]
    [Column("name")]
    public required string Name { get; set; }

    [Required]
    [Column("icd_code")]
    public required string IcdCode { get; set; }

    [Column("description")]
    public string? Description { get; set; }

    [Column("symptoms")]
    public string? Symptoms { get; set; }

    [Column("treatment")]
    public string? Treatment { get; set; }

    [Required]
    [Column("is_chronic")]
    public bool IsChronic { get; set; }

    [Required]
    [Column("created_at")]
    public DateTimeOffset? CreatedAt { get; set; }

    [Required]
    [Column("updated_at")]
    public DateTimeOffset? UpdatedAt { get; set; }

    [Column("deleted_at")]
    public DateTimeOffset? DeletedAt { get; set; }
}
