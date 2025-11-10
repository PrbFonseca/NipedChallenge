using MedicalReports.Core.Entities;
using MedicalReports.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MedicalReports.Infrastructure.Configurations
{
    public class PatientBloodWorkConfiguration : IEntityTypeConfiguration<PatientBloodWork>
    {
        public void Configure(EntityTypeBuilder<PatientBloodWork> builder)
        {
            builder.HasKey(e => e.Id);

            builder.HasOne(e => e.Patient)
                .WithMany(p => p.BloodWork)
                .HasForeignKey(e => e.PatientId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Property(e => e.Category)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(e => e.SubCategory).HasMaxLength(50);

            builder.Property(e => e.Value)
                          .HasPrecision(18, 2);

            // Populate table with seed data
            builder.HasData(PatientsSeedData.GetPatientsBloodWork());
        }
    }
}

