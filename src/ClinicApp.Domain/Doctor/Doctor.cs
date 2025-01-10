using ClinicApp.Domain.Abstractions;
using ClinicApp.Domain.Shared;

namespace ClinicApp.Domain.Doctor
{
    public sealed class Doctor : Entity
    {
        public Doctor(
            Guid id,
            Name doctorName) : base(id)
        {
            DoctorName = doctorName ?? throw new ArgumentNullException(nameof(doctorName));
        }

        public Name DoctorName { get; private set; }

        // Constructor privado para EF Core
        private Doctor() { }

    }
}
