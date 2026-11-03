using Hai.MedicalSystem.Api.Entities.Diseases;
using Hai.MedicalSystem.Api.Entities.Doctors;
using Hai.MedicalSystem.Api.Entities.Patients;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Hai.MedicalSystem.Api.Data
{
    public sealed class ApplicationDbContext : DbContext
    {
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Disease> Diseases { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }
    }
}
