using Moq;
using Moq.EntityFrameworkCore;
using MedicalReports.Application.Handlers;
using MedicalReports.Application.Queries;
using MedicalReports.Application.Interfaces;
using MedicalReports.Core.Entities;
using MedicalReports.Core.Enums;

namespace MedicalReports.Tests.Handlers
{
    [TestClass]
    public class GetPatientHealthReportHandlerTests
    {
        private Mock<IAppDbContext> _mockDbContext;
        private GetPatientHealthReportHandler _getPatientHealthReportHandler;

        [TestInitialize]
        public void Setup()
        {
            _mockDbContext = new Mock<IAppDbContext>();
            _getPatientHealthReportHandler = new GetPatientHealthReportHandler(_mockDbContext.Object);
        }

        [TestMethod]
        public async Task Handle_PatientNotFound_ThrowsException()
        {
            _mockDbContext.Setup(x => x.Patients).ReturnsDbSet(new List<Patient>());

            var query = new GetPatientHealthReportQuery { PatientId = 1 };

            await Assert.ThrowsExceptionAsync<InvalidOperationException>(
                async () => await _getPatientHealthReportHandler.Handle(query, CancellationToken.None));
        }

        [TestMethod]
        public async Task Handle_BloodWorkMatchesGuideline_ReturnsStatus()
        {
            // Arrange
            var patients = new List<Patient>
            {
                new Patient
                {
                    Id = 1,
                    Name = "Test Patient",
                    BloodWork = new List<PatientBloodWork>
                    {
                        new PatientBloodWork { Category = "Cholesterol", SubCategory = "Ldl", Value = 100 }
                    },
                    Questionnaires = new List<PatientQuestionnaire>()
                }
            };

            var guidelines = new List<Guideline>
            {
                new Guideline
                {
                    Category = "Cholesterol",
                    SubCategory = "Ldl",
                    MatchingType = MatchingType.Numeric,
                    GuidelineItems = new List<GuidelineItem>
                    {
                        new GuidelineItem { MinValue = 0, MaxValue = 100, Status = HealthStatus.Optimal }
                    }
                }
            };

            _mockDbContext.Setup(x => x.Patients).ReturnsDbSet(patients);
            _mockDbContext.Setup(x => x.Guidelines).ReturnsDbSet(guidelines);

            var query = new GetPatientHealthReportQuery { PatientId = 1 };

            // Act
            var result = await _getPatientHealthReportHandler.Handle(query, CancellationToken.None);

            // Assert
            Assert.AreEqual(1, result.ReportItems.Count);
            Assert.AreEqual(HealthStatus.Optimal.ToString(), result.ReportItems[0].Status);
        }

        [TestMethod]
        public async Task Handle_BloodWorkUnderMax_ReturnsNeedsAttention()
        {
            // Arrange
            var patients = new List<Patient>
            {
                new Patient
                {
                    Id = 1,
                    Name = "Test Patient",
                    BloodWork = new List<PatientBloodWork>
                    {
                        new PatientBloodWork { Category = "Cholesterol", Value = 90 }
                    },
                }
            };

            var guidelines = new List<Guideline>
            {
                new Guideline
                {
                    Category = "Cholesterol",
                    MatchingType = MatchingType.Numeric,
                    GuidelineItems = new List<GuidelineItem>
                    {
                        new GuidelineItem { MinValue = 0, MaxValue = 100, Status = HealthStatus.Optimal }
                    }
                }
            };

            _mockDbContext.Setup(x => x.Patients).ReturnsDbSet(patients);
            _mockDbContext.Setup(x => x.Guidelines).ReturnsDbSet(guidelines);

            var query = new GetPatientHealthReportQuery { PatientId = 1 };

            // Act
            var result = await _getPatientHealthReportHandler.Handle(query, CancellationToken.None);

            // Assert
            Assert.AreEqual(1, result.ReportItems.Count);
            Assert.AreEqual(HealthStatus.Optimal.ToString(), result.ReportItems[0].Status);
        }

        [TestMethod]
        public async Task Handle_GuidelineNotFound_ReturnsNeedsAttention()
        {
            // Arrange
            var patients = new List<Patient>
            {
                new Patient
                {
                    Id = 1,
                    Name = "Test Patient",
                    BloodWork = new List<PatientBloodWork>
                    {
                        new PatientBloodWork { Category = "Unknown", Value = 100 }
                    }
                }
            };

            _mockDbContext.Setup(x => x.Patients).ReturnsDbSet(patients);
            _mockDbContext.Setup(x => x.Guidelines).ReturnsDbSet(new List<Guideline>());

            var query = new GetPatientHealthReportQuery { PatientId = 1 };

            // Act
            var result = await _getPatientHealthReportHandler.Handle(query, CancellationToken.None);

            // Assert
            Assert.AreEqual("Guideline not found", result.ReportItems[0].Note);
        }

        [TestMethod]
        public async Task Handle_QuestionnaireWithTextMatching_ReturnsCorrectStatus()
        {
            // Arrange
            var patients = new List<Patient>
            {
                new Patient
                {
                    Id = 1,
                    Name = "Test Patient",
                    Questionnaires = new List<PatientQuestionnaire>
                    {
                        new PatientQuestionnaire
                        {
                            Category = "Exercise",
                            ResponseValue = "Daily"
                        }
                    }
                }
            };

            var guidelines = new List<Guideline>
            {
                new Guideline
                {
                    Category = "Exercise",
                    MatchingType = MatchingType.Textual,
                    GuidelineItems = new List<GuidelineItem>
                    {
                        new GuidelineItem { TextualValue = "Daily", Status = HealthStatus.Optimal }
                    }
                }
            };

            _mockDbContext.Setup(x => x.Patients).ReturnsDbSet(patients);
            _mockDbContext.Setup(x => x.Guidelines).ReturnsDbSet(guidelines);

            var query = new GetPatientHealthReportQuery { PatientId = 1 };

            // Act
            var result = await _getPatientHealthReportHandler.Handle(query, CancellationToken.None);

            // Assert
            Assert.AreEqual(1, result.ReportItems.Count);
            Assert.AreEqual(HealthStatus.Optimal.ToString(), result.ReportItems[0].Status);
        }
    }
}