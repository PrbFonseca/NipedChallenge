using MedicalReports.Core.Entities;
using MedicalReports.Core.Enums;

namespace MedicalReports.Infrastructure.Data
{
    public static class GuidelinesSeedData
    {
        public static List<Guideline> GetGuidelines()
        {
            var SeedDate = new DateTime(2025, 1, 1);

            return new List<Guideline>
            {
                new Guideline { Id = 1, Category = "Cholesterol", SubCategory = "Total", MatchingType = MatchingType.Numeric, CreatedAt = SeedDate },
                new Guideline { Id = 2, Category = "Cholesterol", SubCategory = "Hdl", MatchingType = MatchingType.Numeric, CreatedAt = SeedDate  },
                new Guideline { Id = 3, Category = "Cholesterol", SubCategory = "Ldl", MatchingType = MatchingType.Numeric, CreatedAt = SeedDate },
                new Guideline { Id = 4, Category = "BloodSugar", SubCategory = null, MatchingType = MatchingType.Numeric, CreatedAt = SeedDate },
                new Guideline { Id = 5, Category = "BloodPressure", SubCategory = "Systolic", MatchingType = MatchingType.Numeric, CreatedAt = SeedDate },
                new Guideline { Id = 6, Category = "BloodPressure", SubCategory = "Diastolic", MatchingType = MatchingType.Numeric , CreatedAt = SeedDate},
                new Guideline { Id = 7, Category = "ExerciseWeeklyMinutes", SubCategory = null, MatchingType = MatchingType.Numeric , CreatedAt = SeedDate},
                new Guideline { Id = 8, Category = "SleepQuality", SubCategory = null, MatchingType = MatchingType.Textual, CreatedAt = SeedDate },
                new Guideline { Id = 9, Category = "StressLevels", SubCategory = null, MatchingType = MatchingType.Textual, CreatedAt = SeedDate },
                new Guideline { Id = 10, Category = "DietQuality", SubCategory = null, MatchingType = MatchingType.Textual, CreatedAt = SeedDate }
            };
        }

        public static List<GuidelineItem> GetGuidelineItems()
        {
            var SeedDate = new DateTime(2025, 1, 1, 0, 0, 0, DateTimeKind.Utc);

            return new List<GuidelineItem>
                {
                // Cholesterol - Total
                new GuidelineItem { Id = 1, GuidelineId = 1, Status = HealthStatus.Optimal, MinValue = null, MaxValue = 199, CreatedAt = SeedDate },
                new GuidelineItem { Id = 2, GuidelineId = 1, Status = HealthStatus.NeedsAttention, MinValue = 200, MaxValue = 239, CreatedAt = SeedDate },
                new GuidelineItem { Id = 3, GuidelineId = 1, Status = HealthStatus.SeriousIssue, MinValue = 240, MaxValue = null, CreatedAt = SeedDate },
    
                // Cholesterol - Hdl
                new GuidelineItem { Id = 4, GuidelineId = 2, Status = HealthStatus.Optimal, MinValue = 61, MaxValue = null, CreatedAt = SeedDate },
                new GuidelineItem { Id = 5, GuidelineId = 2, Status = HealthStatus.NeedsAttention, MinValue = 40, MaxValue = 60, CreatedAt = SeedDate },
                new GuidelineItem { Id = 6, GuidelineId = 2, Status = HealthStatus.SeriousIssue, MinValue = null, MaxValue = 39, CreatedAt = SeedDate },
    
                // Cholesterol - Ldl
                new GuidelineItem { Id = 7, GuidelineId = 3, Status = HealthStatus.Optimal, MinValue = null, MaxValue = 99, CreatedAt = SeedDate  },
                new GuidelineItem { Id = 8, GuidelineId = 3, Status = HealthStatus.NeedsAttention, MinValue = 100, MaxValue = 129, CreatedAt = SeedDate  },
                new GuidelineItem { Id = 9, GuidelineId = 3, Status = HealthStatus.SeriousIssue, MinValue = 130, MaxValue = null, CreatedAt = SeedDate  },
    
                // Blood Sugar 
                new GuidelineItem { Id = 10, GuidelineId = 4, Status = HealthStatus.Optimal, MinValue = 70, MaxValue = 99, CreatedAt = SeedDate  },
                new GuidelineItem { Id = 11, GuidelineId = 4, Status = HealthStatus.NeedsAttention, MinValue = 100, MaxValue = 125, CreatedAt = SeedDate  },
                new GuidelineItem { Id = 12, GuidelineId = 4, Status = HealthStatus.SeriousIssue, MinValue = 126, MaxValue = null, CreatedAt = SeedDate  },
    
                // Blood Pressure - Systolic 
                new GuidelineItem { Id = 13, GuidelineId = 5, Status = HealthStatus.Optimal, MinValue = null, MaxValue = 119, CreatedAt = SeedDate  },
                new GuidelineItem { Id = 14, GuidelineId = 5, Status = HealthStatus.NeedsAttention, MinValue = 120, MaxValue = 129, CreatedAt = SeedDate  },
                new GuidelineItem { Id = 15, GuidelineId = 5, Status = HealthStatus.SeriousIssue, MinValue = 130, MaxValue = null, CreatedAt = SeedDate  },
    
                // Blood Pressure - Diastolic 
                new GuidelineItem { Id = 16, GuidelineId = 6, Status = HealthStatus.Optimal, MinValue = null, MaxValue = 79, CreatedAt = SeedDate  },
                new GuidelineItem { Id = 17, GuidelineId = 6, Status = HealthStatus.SeriousIssue, MinValue = 80, MaxValue = null, CreatedAt = SeedDate  },
    
                // Exercise Weekly 
                new GuidelineItem { Id = 18, GuidelineId = 7, Status = HealthStatus.Optimal, MinValue = 150, MaxValue = null, CreatedAt = SeedDate  },
                new GuidelineItem { Id = 19, GuidelineId = 7, Status = HealthStatus.NeedsAttention, MinValue = 75, MaxValue = 149, CreatedAt = SeedDate  },
                new GuidelineItem { Id = 20, GuidelineId = 7, Status = HealthStatus.SeriousIssue, MinValue = null, MaxValue = 74, CreatedAt = SeedDate  },
    
                // Sleep Quality 
                new GuidelineItem { Id = 21, GuidelineId = 8, Status = HealthStatus.Optimal, TextualValue = "7-9 hours with restful sleep", CreatedAt = SeedDate },
                new GuidelineItem { Id = 22, GuidelineId = 8, Status = HealthStatus.NeedsAttention, TextualValue = "5-6 hours or frequent disturbances", CreatedAt = SeedDate },
                new GuidelineItem { Id = 23, GuidelineId = 8, Status = HealthStatus.SeriousIssue, TextualValue = "<5 hours or severe sleep issues", CreatedAt = SeedDate },
    
                // Stress levels
                new GuidelineItem { Id = 24, GuidelineId = 9, Status = HealthStatus.Optimal, TextualValue = "Low self-reported stress", CreatedAt = SeedDate  },
                new GuidelineItem { Id = 25, GuidelineId = 9, Status = HealthStatus.NeedsAttention, TextualValue = "Moderate self-reported stress", CreatedAt = SeedDate  },
                new GuidelineItem { Id = 26, GuidelineId = 9, Status = HealthStatus.SeriousIssue, TextualValue = "High chronic stress affecting well-being", CreatedAt = SeedDate  },
    
                // Diet 
                new GuidelineItem { Id = 27, GuidelineId = 10, Status = HealthStatus.Optimal, TextualValue = "Balanced, nutrient-rich diet", CreatedAt = SeedDate  },
                new GuidelineItem { Id = 28, GuidelineId = 10, Status = HealthStatus.NeedsAttention, TextualValue = "Processed or high-sugar diet", CreatedAt = SeedDate  },
                new GuidelineItem { Id = 29, GuidelineId = 10, Status = HealthStatus.SeriousIssue, TextualValue = "Poor nutrition with deficiencies", CreatedAt = SeedDate  }
            };
        }
    }
}
