using MedicalReports.Core.Entities;
using MedicalReports.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MedicalReports.Infrastructure.Configurations
{
    public class PatientConfiguration : IEntityTypeConfiguration<Patient>
    {
        public void Configure(EntityTypeBuilder<Patient> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(e => e.Email)
                .HasMaxLength(255);

            builder.Property(e => e.Gender)
                .HasConversion<string>();

            builder.HasMany(e => e.BloodWork)
                .WithOne(b => b.Patient)
                .HasForeignKey(b => b.PatientId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(e => e.Questionnaires)
                .WithOne(q => q.Patient)
                .HasForeignKey(q => q.PatientId)
                .OnDelete(DeleteBehavior.Cascade);

            // Populate table with seed data
            builder.HasData(PatientsSeedData.GetPatients());
        }
    }
}
