using ClinicApp.Infrastructure;
using ClinicApp.Application;

namespace ClinicApp.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Configuración de appsettings.json
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

            // Agregar capas de aplicación e infraestructura
            builder.Services.AddApplication();
            builder.Services.AddInfrastructure(connectionString);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            //// Configuración de la conexión a la base de datos
            //var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

            //builder.Services.AddInfrastructure(connectionString);

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
