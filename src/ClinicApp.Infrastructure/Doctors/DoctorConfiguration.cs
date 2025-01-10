using ClinicApp.Domain.Doctor;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicApp.Infrastructure.Doctors
{
    public class DoctorConfiguration : IEntityTypeConfiguration<Doctor>
    {
        public void Configure(EntityTypeBuilder<Doctor> builder)
        {
            builder.ToTable("Doctors");

            builder.HasKey(x => x.Id);

            builder.OwnsOne(a => a.DoctorName , name =>
            {
                name.Property(n => n.value)
                .HasColumnName("DoctorName")
                .IsRequired();
            });
        }
    }
}
