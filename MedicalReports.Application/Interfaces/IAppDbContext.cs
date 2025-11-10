using MedicalReports.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace MedicalReports.Application.Interfaces
{
    public interface IAppDbContext
    {
        DbSet<GuidelineItem> GuidelineItems { get; set; }
        DbSet<Guideline> Guidelines { get; set; }
        DbSet<Patient> Patients { get; set; }
        DbSet<PatientBloodWork> PatientsBloodWork { get; set; }
        DbSet<PatientQuestionnaire> PatientsQuestionnaire { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
