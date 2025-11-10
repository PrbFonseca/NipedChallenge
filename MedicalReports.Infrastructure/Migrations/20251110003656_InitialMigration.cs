using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MedicalReports.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Guidelines",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Category = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    SubCategory = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    MatchingType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Unit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Guidelines", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Patients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GuidelineItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MinValue = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: true),
                    MaxValue = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: true),
                    TextualValue = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    GuidelineId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GuidelineItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GuidelineItems_Guidelines_GuidelineId",
                        column: x => x.GuidelineId,
                        principalTable: "Guidelines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PatientsBloodWork",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PatientId = table.Column<int>(type: "int", nullable: false),
                    Category = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    SubCategory = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Value = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    Unit = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MeasurementDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientsBloodWork", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PatientsBloodWork_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PatientsQuestionnaire",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PatientId = table.Column<int>(type: "int", nullable: false),
                    Category = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    SubCategory = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ResponseValue = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    NumericValue = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: true),
                    ResponseDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientsQuestionnaire", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PatientsQuestionnaire_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Guidelines",
                columns: new[] { "Id", "Category", "CreatedAt", "IsActive", "MatchingType", "SubCategory", "Unit", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, "Cholesterol", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Numeric", "Total", null, null },
                    { 2, "Cholesterol", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Numeric", "Hdl", null, null },
                    { 3, "Cholesterol", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Numeric", "Ldl", null, null },
                    { 4, "BloodSugar", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Numeric", null, null, null },
                    { 5, "BloodPressure", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Numeric", "Systolic", null, null },
                    { 6, "BloodPressure", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Numeric", "Diastolic", null, null },
                    { 7, "ExerciseWeeklyMinutes", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Numeric", null, null, null },
                    { 8, "SleepQuality", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Textual", null, null, null },
                    { 9, "StressLevels", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Textual", null, null, null },
                    { 10, "DietQuality", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Textual", null, null, null }
                });

            migrationBuilder.InsertData(
                table: "Patients",
                columns: new[] { "Id", "CreatedAt", "DateOfBirth", "Email", "Gender", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1980, 5, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "john.doe@test.com", "Male", "John Doe", null },
                    { 2, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1992, 8, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "jane.smith@test.com", "Female", "Jane Smith", null },
                    { 3, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1973, 11, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "emily.johnson@test.com", "Female", "Emily Johnson", null },
                    { 4, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1997, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "michael.brown@test.com", "Male", "Michael Brown", null },
                    { 5, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1986, 7, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "sophia.davis@test.com", "Female", "Sophia Davis", null },
                    { 6, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1965, 3, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "james.wilson@test.com", "Male", "James Wilson", null },
                    { 7, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1995, 9, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "laura.martinez@test.com", "Female", "Laura Martinez", null },
                    { 8, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1981, 12, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "daniel.lee@test.com", "Male", "Daniel Lee", null },
                    { 9, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1989, 4, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "olivia.white@test.com", "Female", "Olivia White", null },
                    { 10, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1974, 6, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "william.carter@test.com", "Male", "William Carter", null }
                });

            migrationBuilder.InsertData(
                table: "GuidelineItems",
                columns: new[] { "Id", "CreatedAt", "GuidelineId", "MaxValue", "MinValue", "Status", "TextualValue", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 199m, null, "Optimal", null, null },
                    { 2, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 239m, 200m, "NeedsAttention", null, null },
                    { 3, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, null, 240m, "SeriousIssue", null, null },
                    { 4, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 2, null, 61m, "Optimal", null, null },
                    { 5, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 2, 60m, 40m, "NeedsAttention", null, null },
                    { 6, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 2, 39m, null, "SeriousIssue", null, null },
                    { 7, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 3, 99m, null, "Optimal", null, null },
                    { 8, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 3, 129m, 100m, "NeedsAttention", null, null },
                    { 9, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 3, null, 130m, "SeriousIssue", null, null },
                    { 10, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 4, 99m, 70m, "Optimal", null, null },
                    { 11, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 4, 125m, 100m, "NeedsAttention", null, null },
                    { 12, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 4, null, 126m, "SeriousIssue", null, null },
                    { 13, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 5, 119m, null, "Optimal", null, null },
                    { 14, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 5, 129m, 120m, "NeedsAttention", null, null },
                    { 15, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 5, null, 130m, "SeriousIssue", null, null },
                    { 16, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 6, 79m, null, "Optimal", null, null },
                    { 17, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 6, null, 80m, "SeriousIssue", null, null },
                    { 18, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 7, null, 150m, "Optimal", null, null },
                    { 19, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 7, 149m, 75m, "NeedsAttention", null, null },
                    { 20, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 7, 74m, null, "SeriousIssue", null, null },
                    { 21, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 8, null, null, "Optimal", "7-9 hours with restful sleep", null },
                    { 22, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 8, null, null, "NeedsAttention", "5-6 hours or frequent disturbances", null },
                    { 23, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 8, null, null, "SeriousIssue", "<5 hours or severe sleep issues", null },
                    { 24, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 9, null, null, "Optimal", "Low self-reported stress", null },
                    { 25, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 9, null, null, "NeedsAttention", "Moderate self-reported stress", null },
                    { 26, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 9, null, null, "SeriousIssue", "High chronic stress affecting well-being", null },
                    { 27, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 10, null, null, "Optimal", "Balanced, nutrient-rich diet", null },
                    { 28, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 10, null, null, "NeedsAttention", "Processed or high-sugar diet", null },
                    { 29, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 10, null, null, "SeriousIssue", "Poor nutrition with deficiencies", null }
                });

            migrationBuilder.InsertData(
                table: "PatientsBloodWork",
                columns: new[] { "Id", "Category", "CreatedAt", "MeasurementDate", "PatientId", "SubCategory", "Unit", "UpdatedAt", "Value" },
                values: new object[,]
                {
                    { 1, "Cholesterol", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Total", "", null, 210m },
                    { 2, "Cholesterol", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "HDL", "", null, 50m },
                    { 3, "Cholesterol", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "LDL", "", null, 130m },
                    { 4, "BloodSugar", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, "", null, 95m },
                    { 5, "BloodPressure", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Systolic", "", null, 130m },
                    { 6, "BloodPressure", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Diastolic", "", null, 85m },
                    { 7, "Cholesterol", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Total", "", null, 180m },
                    { 8, "Cholesterol", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "HDL", "", null, 60m },
                    { 9, "Cholesterol", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "LDL", "", null, 100m },
                    { 10, "BloodSugar", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, null, "", null, 85m },
                    { 11, "BloodPressure", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Systolic", "", null, 120m },
                    { 12, "BloodPressure", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Diastolic", "", null, 80m },
                    { 13, "Cholesterol", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "Total", "", null, 250m },
                    { 14, "Cholesterol", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "HDL", "", null, 35m },
                    { 15, "Cholesterol", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "LDL", "", null, 150m },
                    { 16, "BloodSugar", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, null, "", null, 110m },
                    { 17, "BloodPressure", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "Systolic", "", null, 140m },
                    { 18, "BloodPressure", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "Diastolic", "", null, 90m },
                    { 19, "Cholesterol", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "HDL", "", null, 55m },
                    { 20, "Cholesterol", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "LDL", "", null, 120m },
                    { 21, "BloodSugar", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, null, "", null, 90m },
                    { 22, "BloodPressure", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "Systolic", "", null, 118m },
                    { 23, "BloodPressure", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "Diastolic", "", null, 78m },
                    { 24, "Cholesterol", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, "Total", "", null, 220m },
                    { 25, "Cholesterol", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, "HDL", "", null, 45m },
                    { 26, "Cholesterol", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, "LDL", "", null, 135m },
                    { 27, "BloodSugar", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, null, "", null, 100m },
                    { 28, "BloodPressure", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, "Systolic", "", null, 128m },
                    { 29, "BloodPressure", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, "Diastolic", "", null, 83m },
                    { 30, "Cholesterol", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, "Total", "", null, 260m },
                    { 31, "Cholesterol", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, "HDL", "", null, 40m },
                    { 32, "Cholesterol", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, "LDL", "", null, 155m },
                    { 33, "BloodSugar", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, null, "", null, 130m },
                    { 34, "BloodPressure", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, "Systolic", "", null, 145m },
                    { 35, "BloodPressure", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, "Diastolic", "", null, 95m },
                    { 36, "Cholesterol", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 7, "Total", "", null, 185m },
                    { 37, "Cholesterol", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 7, "HDL", "", null, 58m },
                    { 38, "Cholesterol", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 7, "LDL", "", null, 110m },
                    { 39, "BloodSugar", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 7, null, "", null, 92m },
                    { 40, "BloodPressure", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 7, "Systolic", "", null, 122m },
                    { 41, "BloodPressure", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 7, "Diastolic", "", null, 79m },
                    { 42, "Cholesterol", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 8, "Total", "", null, 230m },
                    { 43, "Cholesterol", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 8, "HDL", "", null, 48m },
                    { 44, "Cholesterol", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 8, "LDL", "", null, 140m },
                    { 45, "BloodSugar", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 8, null, "", null, 115m },
                    { 46, "BloodPressure", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 8, "Systolic", "", null, 135m },
                    { 47, "BloodPressure", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 8, "Diastolic", "", null, 87m },
                    { 48, "Cholesterol", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 9, "Total", "", null, 195m },
                    { 49, "Cholesterol", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 9, "HDL", "", null, 52m },
                    { 50, "Cholesterol", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 9, "LDL", "", null, 115m },
                    { 51, "BloodSugar", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 9, null, "", null, 89m },
                    { 52, "BloodPressure", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 9, "Systolic", "", null, 124m },
                    { 53, "BloodPressure", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 9, "Diastolic", "", null, 81m },
                    { 54, "Cholesterol", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 10, "Total", "", null, 240m },
                    { 55, "Cholesterol", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 10, "HDL", "", null, 42m },
                    { 56, "Cholesterol", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 10, "LDL", "", null, 145m },
                    { 57, "BloodSugar", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 10, null, "", null, 125m },
                    { 58, "BloodPressure", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 10, "Systolic", "", null, 138m },
                    { 59, "BloodPressure", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 10, "Diastolic", "", null, 89m }
                });

            migrationBuilder.InsertData(
                table: "PatientsQuestionnaire",
                columns: new[] { "Id", "Category", "CreatedAt", "NumericValue", "PatientId", "ResponseDate", "ResponseValue", "SubCategory", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, "ExerciseWeeklyMinutes", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 90m, 1, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "90", null, null },
                    { 2, "SleepQuality", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "6 hours, frequent disturbances", null, null },
                    { 3, "StressLevels", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Moderate self-reported stress", null, null },
                    { 4, "DietQuality", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Processed or high-sugar diet", null, null },
                    { 5, "ExerciseWeeklyMinutes", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 160m, 2, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "160", null, null },
                    { 6, "SleepQuality", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 2, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "7 hours, restful sleep", null, null },
                    { 7, "StressLevels", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 2, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Low self-reported stress", null, null },
                    { 8, "DietQuality", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 2, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Balanced, nutrient-rich diet", null, null },
                    { 9, "ExerciseWeeklyMinutes", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 60m, 3, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "60", null, null },
                    { 10, "SleepQuality", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 3, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "5 hours, frequent disturbances", null, null },
                    { 11, "StressLevels", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 3, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "High chronic stress affecting well-being", null, null },
                    { 12, "DietQuality", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 3, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Poor nutrition with deficiencies", null, null },
                    { 13, "ExerciseWeeklyMinutes", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 200m, 4, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "200", null, null },
                    { 14, "SleepQuality", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 4, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "8 hours, restful sleep", null, null },
                    { 15, "StressLevels", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 4, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Low self-reported stress", null, null },
                    { 16, "DietQuality", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 4, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Balanced, nutrient-rich diet", null, null },
                    { 17, "ExerciseWeeklyMinutes", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 130m, 5, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "130", null, null },
                    { 18, "SleepQuality", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 5, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "6.5 hours, mild disturbances", null, null },
                    { 19, "StressLevels", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 5, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Moderate self-reported stress", null, null },
                    { 20, "DietQuality", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 5, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Processed or high-sugar diet", null, null },
                    { 21, "ExerciseWeeklyMinutes", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 40m, 6, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "40", null, null },
                    { 22, "SleepQuality", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 6, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "4.5 hours, severe sleep issues", null, null },
                    { 23, "StressLevels", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 6, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "High chronic stress affecting well-being", null, null },
                    { 24, "DietQuality", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 6, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Poor nutrition with deficiencies", null, null },
                    { 25, "ExerciseWeeklyMinutes", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 170m, 7, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "170", null, null },
                    { 26, "SleepQuality", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 7, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "7.5 hours, restful sleep", null, null },
                    { 27, "StressLevels", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 7, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Low self-reported stress", null, null },
                    { 28, "DietQuality", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 7, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Balanced, nutrient-rich diet", null, null },
                    { 29, "ExerciseWeeklyMinutes", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 80m, 8, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "80", null, null },
                    { 30, "SleepQuality", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 8, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "6 hours, mild disturbances", null, null },
                    { 31, "StressLevels", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 8, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Moderate self-reported stress", null, null },
                    { 32, "DietQuality", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 8, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Processed or high-sugar diet", null, null },
                    { 33, "ExerciseWeeklyMinutes", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 150m, 9, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "150", null, null },
                    { 34, "SleepQuality", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 9, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "7 hours, restful sleep", null, null },
                    { 35, "StressLevels", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 9, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Low self-reported stress", null, null },
                    { 36, "DietQuality", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 9, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Balanced, nutrient-rich diet", null, null },
                    { 37, "ExerciseWeeklyMinutes", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 55m, 10, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "55", null, null },
                    { 38, "SleepQuality", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 10, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "5 hours, frequent disturbances", null, null },
                    { 39, "StressLevels", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 10, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "High chronic stress affecting well-being", null, null },
                    { 40, "DietQuality", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 10, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Poor nutrition with deficiencies", null, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_GuidelineItems_GuidelineId",
                table: "GuidelineItems",
                column: "GuidelineId");

            migrationBuilder.CreateIndex(
                name: "IX_Guidelines_Category_SubCategory",
                table: "Guidelines",
                columns: new[] { "Category", "SubCategory" },
                unique: true,
                filter: "[SubCategory] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_PatientsBloodWork_PatientId",
                table: "PatientsBloodWork",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientsQuestionnaire_PatientId",
                table: "PatientsQuestionnaire",
                column: "PatientId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GuidelineItems");

            migrationBuilder.DropTable(
                name: "PatientsBloodWork");

            migrationBuilder.DropTable(
                name: "PatientsQuestionnaire");

            migrationBuilder.DropTable(
                name: "Guidelines");

            migrationBuilder.DropTable(
                name: "Patients");
        }
    }
}
