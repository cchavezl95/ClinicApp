using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace ClinicApp.Infrastructure.Persistence
{
    public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            // Construir las opciones para el DbContext
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();

            // Configuración para tiempo de diseño (actualiza la cadena de conexión)
            optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=ClinicApp;Trusted_Connection=True;TrustServerCertificate=True;");

            return new ApplicationDbContext(optionsBuilder.Options);
        }
    }
}
