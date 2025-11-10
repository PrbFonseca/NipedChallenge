using MedicalReports.Application.Interfaces;
using MedicalReports.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace MedicalReports.Infrastructure.Data
{
    public class AppDbContext : DbContext, IAppDbContext
    {
        public DbSet<Guideline> Guidelines { get; set; }
        public DbSet<GuidelineItem> GuidelineItems { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<PatientBloodWork> PatientsBloodWork { get; set; }
        public DbSet<PatientQuestionnaire> PatientsQuestionnaire { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}


