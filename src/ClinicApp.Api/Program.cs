using ClinicApp.Infrastructure;
using ClinicApp.Application;

namespace ClinicApp.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Configuraci�n de appsettings.json
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

            // Agregar capas de aplicaci�n e infraestructura
            builder.Services.AddApplication();
            builder.Services.AddInfrastructure(connectionString);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            //// Configuraci�n de la conexi�n a la base de datos
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
