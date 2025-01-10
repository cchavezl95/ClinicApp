using ClinicApp.Domain.Appointment;
using ClinicApp.Domain.Doctor;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClinicApp.Infrastructure.Appointments
{
    public class AppointmentConfiguration : IEntityTypeConfiguration<Appointment>
    {
        public void Configure(EntityTypeBuilder<Appointment> builder)
        {
            // Configuración de la tabla
            builder.ToTable("Appointments");

            // Configuración de la clave primaria
            builder.HasKey(a => a.Id);

            // Configuración de los objetos de valor (Value Objects)
            builder.OwnsOne(a => a.PatientName, name =>
            {
                name.Property(n => n.value)
                    .HasColumnName("PatientName")
                    .IsRequired();
            });

            builder.OwnsOne(a => a.Date, date =>
            {
                date.Property(d => d.Date)
                    .HasColumnName("AppointmentDate")
                    .IsRequired();
            });

            builder.OwnsOne(a => a.Status, value =>
            {
                value.Property(d => d.value)
                .HasColumnName("AppointmentStatus")
                .IsRequired();
            });

            builder.HasOne<Doctor>()
                .WithMany()
                .HasForeignKey(x => x.DoctorId);
        }
    }
}
