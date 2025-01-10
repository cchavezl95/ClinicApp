using ClinicApp.Domain.Appointment;
using ClinicApp.Domain.Doctor;
using ClinicApp.Infrastructure.Appointments;
using ClinicApp.Infrastructure.Doctors;
using Microsoft.EntityFrameworkCore;

namespace ClinicApp.Infrastructure.Persistence
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Aplicar configuraciones específicas
            modelBuilder.ApplyConfiguration(new AppointmentConfiguration());
            modelBuilder.ApplyConfiguration(new DoctorConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}
