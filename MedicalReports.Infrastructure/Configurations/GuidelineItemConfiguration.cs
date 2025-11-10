using MedicalReports.Core.Entities;
using MedicalReports.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MedicalReports.Infrastructure.Configurations
{
    public class GuidelineItemConfiguration : IEntityTypeConfiguration<GuidelineItem>
    {
        public void Configure(EntityTypeBuilder<GuidelineItem> builder)
        {
            builder.HasKey(e => e.Id);

            builder.HasOne(e => e.Guideline)
                .WithMany(g => g.GuidelineItems)
                .HasForeignKey(e => e.GuidelineId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Property(e => e.TextualValue)
                .HasMaxLength(100);

            builder.Property(e => e.MinValue)
                          .HasPrecision(18, 2); 

            builder.Property(e => e.MaxValue)
                .HasPrecision(18, 2);

            builder.Property(g => g.Status)
                .HasConversion<string>();

            // Populate table with seed data
            builder.HasData(GuidelinesSeedData.GetGuidelineItems());
        }
    }
}