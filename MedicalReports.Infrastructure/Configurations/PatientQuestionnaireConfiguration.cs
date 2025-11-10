using MedicalReports.Core.Entities;
using MedicalReports.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MedicalReports.Infrastructure.Configurations
{
    public class PatientQuestionnaireConfiguration : IEntityTypeConfiguration<PatientQuestionnaire>
    {
        public void Configure(EntityTypeBuilder<PatientQuestionnaire> builder)
        {
            builder.HasKey(e => e.Id);

            builder.HasOne(e => e.Patient)
                .WithMany(p => p.Questionnaires)
                .HasForeignKey(e => e.PatientId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Property(e => e.Category)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(e => e.SubCategory).HasMaxLength(50);

            builder.Property(e => e.ResponseValue)
                .HasMaxLength(50);

            builder.Property(e => e.NumericValue)
                .HasPrecision(18, 4);

            // Populate table with seed data
            builder.HasData(PatientsSeedData.GetPatientsQuestionnaire());
        }
    }
}
