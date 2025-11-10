using MedicalReports.Core.Entities;
using MedicalReports.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MedicalReports.Infrastructure.Configurations
{
    public class GuidelineConfiguration : IEntityTypeConfiguration<Guideline>
    {
        public void Configure(EntityTypeBuilder<Guideline> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Category)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(e => e.SubCategory).HasMaxLength(50);

            builder.HasIndex(e => new { e.Category, e.SubCategory }).IsUnique();

            builder.Property(g => g.MatchingType)
                .HasConversion<string>();

            // Populate table with seed data
            builder.HasData(GuidelinesSeedData.GetGuidelines());
        }
    }
}
