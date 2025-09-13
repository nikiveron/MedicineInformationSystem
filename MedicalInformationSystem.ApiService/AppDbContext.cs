using MedicalInformationSystem.ApiService.Models;
using Microsoft.EntityFrameworkCore;
using System.Numerics;

namespace MedicalInformationSystem.ApiService;

public class AppDbContext : DbContext
{
    public DbSet<PatientEntity> Patients => Set<PatientEntity>();
    public DbSet<AppointmentEntity> Appointments => Set<AppointmentEntity>();
    public DbSet<DiseaseEntity> Diseases => Set<DiseaseEntity>();
    public DbSet<DoctorEntity> Doctors => Set<DoctorEntity>();

    public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
    {
        Database.Migrate();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<AppointmentEntity>()
            .HasOne<PatientEntity>()                    
            .WithMany()                                 
            .HasForeignKey(a => a.PatientId);            

        modelBuilder.Entity<AppointmentEntity>()
            .HasOne<DoctorEntity>()
            .WithMany()
            .HasForeignKey(a => a.DoctorId);

        modelBuilder.Entity<AppointmentEntity>()
            .HasOne<DiseaseEntity>()
            .WithMany()
            .HasForeignKey(a => a.DiseaseId);
    }

}

