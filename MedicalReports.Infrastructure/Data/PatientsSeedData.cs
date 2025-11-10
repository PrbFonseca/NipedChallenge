using MedicalReports.Core.Entities;
using MedicalReports.Core.Enums;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalReports.Infrastructure.Data
{
    public static class PatientsSeedData
    {
        public static List<Patient> GetPatients()
        {
            var SeedDate = new DateTime(2025, 1, 1);

            return new List<Patient> 
            {
                new Patient { Id = 1, Name = "John Doe", DateOfBirth = new DateTime(1980, 5, 14), Gender = Gender.Male, Email = "john.doe@test.com", CreatedAt = SeedDate  },
                new Patient { Id = 2, Name = "Jane Smith", DateOfBirth = new DateTime(1992, 8, 22), Gender = Gender.Female, Email = "jane.smith@test.com", CreatedAt = SeedDate  },
                new Patient { Id = 3, Name = "Emily Johnson", DateOfBirth = new DateTime(1973, 11, 5), Gender = Gender.Female, Email = "emily.johnson@test.com", CreatedAt = SeedDate  },
                new Patient { Id = 4, Name = "Michael Brown", DateOfBirth = new DateTime(1997, 2, 10), Gender = Gender.Male, Email = "michael.brown@test.com", CreatedAt = SeedDate  },
                new Patient { Id = 5, Name = "Sophia Davis", DateOfBirth = new DateTime(1986, 7, 18), Gender = Gender.Female, Email = "sophia.davis@test.com", CreatedAt = SeedDate  },
                new Patient { Id = 6, Name = "James Wilson", DateOfBirth = new DateTime(1965, 3, 25), Gender = Gender.Male, Email = "james.wilson@test.com", CreatedAt = SeedDate  },
                new Patient { Id = 7, Name = "Laura Martinez", DateOfBirth = new DateTime(1995, 9, 30), Gender = Gender.Female, Email = "laura.martinez@test.com", CreatedAt = SeedDate  },
                new Patient { Id = 8, Name = "Daniel Lee", DateOfBirth = new DateTime(1981, 12, 11), Gender = Gender.Male, Email = "daniel.lee@test.com", CreatedAt = SeedDate  },
                new Patient { Id = 9, Name = "Olivia White", DateOfBirth = new DateTime(1989, 4, 7), Gender = Gender.Female, Email = "olivia.white@test.com", CreatedAt = SeedDate  },
                new Patient { Id = 10, Name = "William Carter", DateOfBirth = new DateTime(1974, 6, 14), Gender = Gender.Male, Email = "william.carter@test.com", CreatedAt = SeedDate  }
            };
        }

        public static List<PatientBloodWork> GetPatientsBloodWork()
        {
            var SeedDate = new DateTime(2025, 1, 1);
            var count = 1;

            return new List<PatientBloodWork>
            {
                new PatientBloodWork { Id = count++, PatientId = 1, Category = "Cholesterol", SubCategory = "Total", Value = 210, MeasurementDate = SeedDate, CreatedAt = SeedDate },
                new PatientBloodWork { Id = count++, PatientId = 1, Category = "Cholesterol", SubCategory = "HDL", Value = 50, MeasurementDate = SeedDate, CreatedAt = SeedDate },
                new PatientBloodWork { Id = count++, PatientId = 1, Category = "Cholesterol", SubCategory = "LDL", Value = 130, MeasurementDate = SeedDate, CreatedAt = SeedDate },
                new PatientBloodWork { Id = count++, PatientId = 1, Category = "BloodSugar", SubCategory = null, Value = 95, MeasurementDate = SeedDate, CreatedAt = SeedDate },
                new PatientBloodWork { Id = count++, PatientId = 1, Category = "BloodPressure", SubCategory = "Systolic", Value = 130, MeasurementDate = SeedDate, CreatedAt = SeedDate },
                new PatientBloodWork { Id = count++, PatientId = 1, Category = "BloodPressure", SubCategory = "Diastolic", Value = 85, MeasurementDate = SeedDate, CreatedAt = SeedDate },
 
                new PatientBloodWork { Id = count++, PatientId = 2, Category = "Cholesterol", SubCategory = "Total", Value = 180, MeasurementDate = SeedDate, CreatedAt = SeedDate },
                new PatientBloodWork { Id = count++, PatientId = 2, Category = "Cholesterol", SubCategory = "HDL", Value = 60, MeasurementDate = SeedDate, CreatedAt = SeedDate },
                new PatientBloodWork { Id = count++, PatientId = 2, Category = "Cholesterol", SubCategory = "LDL", Value = 100, MeasurementDate = SeedDate, CreatedAt = SeedDate },
                new PatientBloodWork { Id = count++, PatientId = 2, Category = "BloodSugar", SubCategory = null, Value = 85, MeasurementDate = SeedDate, CreatedAt = SeedDate },
                new PatientBloodWork { Id = count++, PatientId = 2, Category = "BloodPressure", SubCategory = "Systolic", Value = 120, MeasurementDate = SeedDate, CreatedAt = SeedDate },
                new PatientBloodWork { Id = count++, PatientId = 2, Category = "BloodPressure", SubCategory = "Diastolic", Value = 80, MeasurementDate = SeedDate, CreatedAt = SeedDate },

                new PatientBloodWork { Id = count++, PatientId = 3, Category = "Cholesterol", SubCategory = "Total", Value = 250, MeasurementDate = SeedDate, CreatedAt = SeedDate },
                new PatientBloodWork { Id = count++, PatientId = 3, Category = "Cholesterol", SubCategory = "HDL", Value = 35, MeasurementDate = SeedDate, CreatedAt = SeedDate },
                new PatientBloodWork { Id = count++, PatientId = 3, Category = "Cholesterol", SubCategory = "LDL", Value = 150, MeasurementDate = SeedDate, CreatedAt = SeedDate },
                new PatientBloodWork { Id = count++, PatientId = 3, Category = "BloodSugar", SubCategory = null, Value = 110, MeasurementDate = SeedDate, CreatedAt = SeedDate },
                new PatientBloodWork { Id = count++, PatientId = 3, Category = "BloodPressure", SubCategory = "Systolic", Value = 140, MeasurementDate = SeedDate, CreatedAt = SeedDate },
                new PatientBloodWork { Id = count++, PatientId = 3, Category = "BloodPressure", SubCategory = "Diastolic", Value = 90, MeasurementDate = SeedDate, CreatedAt = SeedDate },
  
                new PatientBloodWork { Id = count++, PatientId = 4, Category = "Cholesterol", SubCategory = "HDL", Value = 55, MeasurementDate = SeedDate, CreatedAt = SeedDate },
                new PatientBloodWork { Id = count++, PatientId = 4, Category = "Cholesterol", SubCategory = "LDL", Value = 120, MeasurementDate = SeedDate, CreatedAt = SeedDate },
                new PatientBloodWork { Id = count++, PatientId = 4, Category = "BloodSugar", SubCategory = null, Value = 90, MeasurementDate = SeedDate, CreatedAt = SeedDate },
                new PatientBloodWork { Id = count++, PatientId = 4, Category = "BloodPressure", SubCategory = "Systolic", Value = 118, MeasurementDate = SeedDate, CreatedAt = SeedDate },
                new PatientBloodWork { Id = count++, PatientId = 4, Category = "BloodPressure", SubCategory = "Diastolic", Value = 78, MeasurementDate = SeedDate, CreatedAt = SeedDate },

                new PatientBloodWork { Id = count++, PatientId = 5, Category = "Cholesterol", SubCategory = "Total", Value = 220, MeasurementDate = SeedDate, CreatedAt = SeedDate },
                new PatientBloodWork { Id = count++, PatientId = 5, Category = "Cholesterol", SubCategory = "HDL", Value = 45, MeasurementDate = SeedDate, CreatedAt = SeedDate },
                new PatientBloodWork { Id = count++, PatientId = 5, Category = "Cholesterol", SubCategory = "LDL", Value = 135, MeasurementDate = SeedDate, CreatedAt = SeedDate },
                new PatientBloodWork { Id = count++, PatientId = 5, Category = "BloodSugar", SubCategory = null, Value = 100, MeasurementDate = SeedDate, CreatedAt = SeedDate },
                new PatientBloodWork { Id = count++, PatientId = 5, Category = "BloodPressure", SubCategory = "Systolic", Value = 128, MeasurementDate = SeedDate, CreatedAt = SeedDate },
                new PatientBloodWork { Id = count++, PatientId = 5, Category = "BloodPressure", SubCategory = "Diastolic", Value = 83, MeasurementDate = SeedDate, CreatedAt = SeedDate },

                new PatientBloodWork { Id = count++, PatientId = 6, Category = "Cholesterol", SubCategory = "Total", Value = 260, MeasurementDate = SeedDate, CreatedAt = SeedDate },
                new PatientBloodWork { Id = count++, PatientId = 6, Category = "Cholesterol", SubCategory = "HDL", Value = 40, MeasurementDate = SeedDate, CreatedAt = SeedDate },
                new PatientBloodWork { Id = count++, PatientId = 6, Category = "Cholesterol", SubCategory = "LDL", Value = 155, MeasurementDate = SeedDate, CreatedAt = SeedDate },
                new PatientBloodWork { Id = count++, PatientId = 6, Category = "BloodSugar", SubCategory = null, Value = 130, MeasurementDate = SeedDate, CreatedAt = SeedDate },
                new PatientBloodWork { Id = count++, PatientId = 6, Category = "BloodPressure", SubCategory = "Systolic", Value = 145, MeasurementDate = SeedDate, CreatedAt = SeedDate },
                new PatientBloodWork { Id = count++, PatientId = 6, Category = "BloodPressure", SubCategory = "Diastolic", Value = 95, MeasurementDate = SeedDate, CreatedAt = SeedDate },

                new PatientBloodWork { Id = count++, PatientId = 7, Category = "Cholesterol", SubCategory = "Total", Value = 185, MeasurementDate = SeedDate, CreatedAt = SeedDate },
                new PatientBloodWork { Id = count++, PatientId = 7, Category = "Cholesterol", SubCategory = "HDL", Value = 58, MeasurementDate = SeedDate, CreatedAt = SeedDate },
                new PatientBloodWork { Id = count++, PatientId = 7, Category = "Cholesterol", SubCategory = "LDL", Value = 110, MeasurementDate = SeedDate, CreatedAt = SeedDate },
                new PatientBloodWork { Id = count++, PatientId = 7, Category = "BloodSugar", SubCategory = null, Value = 92, MeasurementDate = SeedDate, CreatedAt = SeedDate },
                new PatientBloodWork { Id = count++, PatientId = 7, Category = "BloodPressure", SubCategory = "Systolic", Value = 122, MeasurementDate = SeedDate, CreatedAt = SeedDate },
                new PatientBloodWork { Id = count++, PatientId = 7, Category = "BloodPressure", SubCategory = "Diastolic", Value = 79, MeasurementDate = SeedDate, CreatedAt = SeedDate },

                new PatientBloodWork { Id = count++, PatientId = 8, Category = "Cholesterol", SubCategory = "Total", Value = 230, MeasurementDate = SeedDate, CreatedAt = SeedDate },
                new PatientBloodWork { Id = count++, PatientId = 8, Category = "Cholesterol", SubCategory = "HDL", Value = 48, MeasurementDate = SeedDate, CreatedAt = SeedDate },
                new PatientBloodWork { Id = count++, PatientId = 8, Category = "Cholesterol", SubCategory = "LDL", Value = 140, MeasurementDate = SeedDate, CreatedAt = SeedDate },
                new PatientBloodWork { Id = count++, PatientId = 8, Category = "BloodSugar", SubCategory = null, Value = 115, MeasurementDate = SeedDate, CreatedAt = SeedDate },
                new PatientBloodWork { Id = count++, PatientId = 8, Category = "BloodPressure", SubCategory = "Systolic", Value = 135, MeasurementDate = SeedDate, CreatedAt = SeedDate },
                new PatientBloodWork { Id = count++, PatientId = 8, Category = "BloodPressure", SubCategory = "Diastolic", Value = 87, MeasurementDate = SeedDate, CreatedAt = SeedDate },

                new PatientBloodWork { Id = count++, PatientId = 9, Category = "Cholesterol", SubCategory = "Total", Value = 195, MeasurementDate = SeedDate, CreatedAt = SeedDate },
                new PatientBloodWork { Id = count++, PatientId = 9, Category = "Cholesterol", SubCategory = "HDL", Value = 52, MeasurementDate = SeedDate, CreatedAt = SeedDate },
                new PatientBloodWork { Id = count++, PatientId = 9, Category = "Cholesterol", SubCategory = "LDL", Value = 115, MeasurementDate = SeedDate, CreatedAt = SeedDate },
                new PatientBloodWork { Id = count++, PatientId = 9, Category = "BloodSugar", SubCategory = null, Value = 89, MeasurementDate = SeedDate, CreatedAt = SeedDate },
                new PatientBloodWork { Id = count++, PatientId = 9, Category = "BloodPressure", SubCategory = "Systolic", Value = 124, MeasurementDate = SeedDate, CreatedAt = SeedDate },
                new PatientBloodWork { Id = count++, PatientId = 9, Category = "BloodPressure", SubCategory = "Diastolic", Value = 81, MeasurementDate = SeedDate, CreatedAt = SeedDate },

                new PatientBloodWork { Id = count++, PatientId = 10, Category = "Cholesterol", SubCategory = "Total", Value = 240, MeasurementDate = SeedDate, CreatedAt = SeedDate },
                new PatientBloodWork { Id = count++, PatientId = 10, Category = "Cholesterol", SubCategory = "HDL", Value = 42, MeasurementDate = SeedDate, CreatedAt = SeedDate },
                new PatientBloodWork { Id = count++, PatientId = 10, Category = "Cholesterol", SubCategory = "LDL", Value = 145, MeasurementDate = SeedDate, CreatedAt = SeedDate },
                new PatientBloodWork { Id = count++, PatientId = 10, Category = "BloodSugar", SubCategory = null, Value = 125, MeasurementDate = SeedDate, CreatedAt = SeedDate },
                new PatientBloodWork { Id = count++, PatientId = 10, Category = "BloodPressure", SubCategory = "Systolic", Value = 138, MeasurementDate = SeedDate, CreatedAt = SeedDate },
                new PatientBloodWork { Id = count++, PatientId = 10, Category = "BloodPressure", SubCategory = "Diastolic", Value = 89, MeasurementDate = SeedDate, CreatedAt = SeedDate }
            };

        }

        public static List<PatientQuestionnaire> GetPatientsQuestionnaire()
        {
            var SeedDate = new DateTime(2025, 1, 1);
            var count = 1;

            return new List<PatientQuestionnaire>
            {
                new PatientQuestionnaire { Id = count++, PatientId = 1, Category = "ExerciseWeeklyMinutes", SubCategory = null, ResponseValue = "90", NumericValue = 90, ResponseDate = SeedDate, CreatedAt = SeedDate },
                new PatientQuestionnaire { Id = count++, PatientId = 1, Category = "SleepQuality", SubCategory = null, ResponseValue = "6 hours, frequent disturbances", NumericValue = null, ResponseDate = SeedDate, CreatedAt = SeedDate },
                new PatientQuestionnaire { Id = count++, PatientId = 1, Category = "StressLevels", SubCategory = null, ResponseValue = "Moderate self-reported stress", NumericValue = null, ResponseDate = SeedDate, CreatedAt = SeedDate },
                new PatientQuestionnaire { Id = count++, PatientId = 1, Category = "DietQuality", SubCategory = null, ResponseValue = "Processed or high-sugar diet", NumericValue = null, ResponseDate = SeedDate, CreatedAt = SeedDate },

                new PatientQuestionnaire { Id = count++, PatientId = 2, Category = "ExerciseWeeklyMinutes", SubCategory = null, ResponseValue = "160", NumericValue = 160, ResponseDate = SeedDate, CreatedAt = SeedDate },
                new PatientQuestionnaire { Id = count++, PatientId = 2, Category = "SleepQuality", SubCategory = null, ResponseValue = "7 hours, restful sleep", NumericValue = null, ResponseDate = SeedDate, CreatedAt = SeedDate },
                new PatientQuestionnaire { Id = count++, PatientId = 2, Category = "StressLevels", SubCategory = null, ResponseValue = "Low self-reported stress", NumericValue = null, ResponseDate = SeedDate, CreatedAt = SeedDate },
                new PatientQuestionnaire { Id = count++, PatientId = 2, Category = "DietQuality", SubCategory = null, ResponseValue = "Balanced, nutrient-rich diet", NumericValue = null, ResponseDate = SeedDate, CreatedAt = SeedDate },

                new PatientQuestionnaire { Id = count++, PatientId = 3, Category = "ExerciseWeeklyMinutes", SubCategory = null, ResponseValue = "60", NumericValue = 60, ResponseDate = SeedDate, CreatedAt = SeedDate },
                new PatientQuestionnaire { Id = count++, PatientId = 3, Category = "SleepQuality", SubCategory = null, ResponseValue = "5 hours, frequent disturbances", NumericValue = null, ResponseDate = SeedDate, CreatedAt = SeedDate },
                new PatientQuestionnaire { Id = count++, PatientId = 3, Category = "StressLevels", SubCategory = null, ResponseValue = "High chronic stress affecting well-being", NumericValue = null, ResponseDate = SeedDate, CreatedAt = SeedDate },
                new PatientQuestionnaire { Id = count++, PatientId = 3, Category = "DietQuality", SubCategory = null, ResponseValue = "Poor nutrition with deficiencies", NumericValue = null, ResponseDate = SeedDate, CreatedAt = SeedDate },

                new PatientQuestionnaire { Id = count++, PatientId = 4, Category = "ExerciseWeeklyMinutes", SubCategory = null, ResponseValue = "200", NumericValue = 200, ResponseDate = SeedDate, CreatedAt = SeedDate },
                new PatientQuestionnaire { Id = count++, PatientId = 4, Category = "SleepQuality", SubCategory = null, ResponseValue = "8 hours, restful sleep", NumericValue = null, ResponseDate = SeedDate, CreatedAt = SeedDate },
                new PatientQuestionnaire { Id = count++, PatientId = 4, Category = "StressLevels", SubCategory = null, ResponseValue = "Low self-reported stress", NumericValue = null, ResponseDate = SeedDate, CreatedAt = SeedDate },
                new PatientQuestionnaire { Id = count++, PatientId = 4, Category = "DietQuality", SubCategory = null, ResponseValue = "Balanced, nutrient-rich diet", NumericValue = null, ResponseDate = SeedDate, CreatedAt = SeedDate },

                new PatientQuestionnaire { Id = count++, PatientId = 5, Category = "ExerciseWeeklyMinutes", SubCategory = null, ResponseValue = "130", NumericValue = 130, ResponseDate = SeedDate, CreatedAt = SeedDate },
                new PatientQuestionnaire { Id = count++, PatientId = 5, Category = "SleepQuality", SubCategory = null, ResponseValue = "6.5 hours, mild disturbances", NumericValue = null, ResponseDate = SeedDate, CreatedAt = SeedDate },
                new PatientQuestionnaire { Id = count++, PatientId = 5, Category = "StressLevels", SubCategory = null, ResponseValue = "Moderate self-reported stress", NumericValue = null, ResponseDate = SeedDate, CreatedAt = SeedDate },
                new PatientQuestionnaire { Id = count++, PatientId = 5, Category = "DietQuality", SubCategory = null, ResponseValue = "Processed or high-sugar diet", NumericValue = null, ResponseDate = SeedDate, CreatedAt = SeedDate },

                new PatientQuestionnaire { Id = count++, PatientId = 6, Category = "ExerciseWeeklyMinutes", SubCategory = null, ResponseValue = "40", NumericValue = 40, ResponseDate = SeedDate, CreatedAt = SeedDate },
                new PatientQuestionnaire { Id = count++, PatientId = 6, Category = "SleepQuality", SubCategory = null, ResponseValue = "4.5 hours, severe sleep issues", NumericValue = null, ResponseDate = SeedDate, CreatedAt = SeedDate },
                new PatientQuestionnaire { Id = count++, PatientId = 6, Category = "StressLevels", SubCategory = null, ResponseValue = "High chronic stress affecting well-being", NumericValue = null, ResponseDate = SeedDate, CreatedAt = SeedDate },
                new PatientQuestionnaire { Id = count++, PatientId = 6, Category = "DietQuality", SubCategory = null, ResponseValue = "Poor nutrition with deficiencies", NumericValue = null, ResponseDate = SeedDate, CreatedAt = SeedDate },

                new PatientQuestionnaire { Id = count++, PatientId = 7, Category = "ExerciseWeeklyMinutes", SubCategory = null, ResponseValue = "170", NumericValue = 170, ResponseDate = SeedDate, CreatedAt = SeedDate },
                new PatientQuestionnaire { Id = count++, PatientId = 7, Category = "SleepQuality", SubCategory = null, ResponseValue = "7.5 hours, restful sleep", NumericValue = null, ResponseDate = SeedDate, CreatedAt = SeedDate },
                new PatientQuestionnaire { Id = count++, PatientId = 7, Category = "StressLevels", SubCategory = null, ResponseValue = "Low self-reported stress", NumericValue = null, ResponseDate = SeedDate, CreatedAt = SeedDate },
                new PatientQuestionnaire { Id = count++, PatientId = 7, Category = "DietQuality", SubCategory = null, ResponseValue = "Balanced, nutrient-rich diet", NumericValue = null, ResponseDate = SeedDate, CreatedAt = SeedDate },

                new PatientQuestionnaire { Id = count++, PatientId = 8, Category = "ExerciseWeeklyMinutes", SubCategory = null, ResponseValue = "80", NumericValue = 80, ResponseDate = SeedDate, CreatedAt = SeedDate },
                new PatientQuestionnaire { Id = count++, PatientId = 8, Category = "SleepQuality", SubCategory = null, ResponseValue = "6 hours, mild disturbances", NumericValue = null, ResponseDate = SeedDate, CreatedAt = SeedDate },
                new PatientQuestionnaire { Id = count++, PatientId = 8, Category = "StressLevels", SubCategory = null, ResponseValue = "Moderate self-reported stress", NumericValue = null, ResponseDate = SeedDate, CreatedAt = SeedDate },
                new PatientQuestionnaire { Id = count++, PatientId = 8, Category = "DietQuality", SubCategory = null, ResponseValue = "Processed or high-sugar diet", NumericValue = null, ResponseDate = SeedDate, CreatedAt = SeedDate },

                new PatientQuestionnaire { Id = count++, PatientId = 9, Category = "ExerciseWeeklyMinutes", SubCategory = null, ResponseValue = "150", NumericValue = 150, ResponseDate = SeedDate, CreatedAt = SeedDate },
                new PatientQuestionnaire { Id = count++, PatientId = 9, Category = "SleepQuality", SubCategory = null, ResponseValue = "7 hours, restful sleep", NumericValue = null, ResponseDate = SeedDate, CreatedAt = SeedDate },
                new PatientQuestionnaire { Id = count++, PatientId = 9, Category = "StressLevels", SubCategory = null, ResponseValue = "Low self-reported stress", NumericValue = null, ResponseDate = SeedDate, CreatedAt = SeedDate },
                new PatientQuestionnaire { Id = count++, PatientId = 9, Category = "DietQuality", SubCategory = null, ResponseValue = "Balanced, nutrient-rich diet", NumericValue = null, ResponseDate = SeedDate, CreatedAt = SeedDate },

                new PatientQuestionnaire { Id = count++, PatientId = 10, Category = "ExerciseWeeklyMinutes", SubCategory = null, ResponseValue = "55", NumericValue = 55, ResponseDate = SeedDate, CreatedAt = SeedDate },
                new PatientQuestionnaire { Id = count++, PatientId = 10, Category = "SleepQuality", SubCategory = null, ResponseValue = "5 hours, frequent disturbances", NumericValue = null, ResponseDate = SeedDate, CreatedAt = SeedDate },
                new PatientQuestionnaire { Id = count++, PatientId = 10, Category = "StressLevels", SubCategory = null, ResponseValue = "High chronic stress affecting well-being", NumericValue = null, ResponseDate = SeedDate, CreatedAt = SeedDate },
                new PatientQuestionnaire { Id = count++, PatientId = 10, Category = "DietQuality", SubCategory = null, ResponseValue = "Poor nutrition with deficiencies", NumericValue = null, ResponseDate = SeedDate, CreatedAt = SeedDate }
            };
        }
    }
}
