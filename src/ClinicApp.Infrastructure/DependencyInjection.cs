using ClinicApp.Domain.Appointment;
using ClinicApp.Domain.Doctor;
using ClinicApp.Infrastructure.Doctors;
using ClinicApp.Infrastructure.Persistence;
using ClinicApp.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace ClinicApp.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, string connectionString)
        {
            // Configuración de EF Core con SQL Server
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(connectionString));

            // Registro de repositorios
            services.AddScoped<IAppointmentRepository, AppointmentRepository>();
            services.AddScoped<IDoctorRepository, DoctorRepository>();

            return services;
        }
    }
}
