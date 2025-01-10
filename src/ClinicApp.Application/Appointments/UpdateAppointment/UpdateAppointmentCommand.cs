using ClinicApp.Application.Abstractions.CQRS;
using ClinicApp.Domain.Abstractions;

namespace ClinicApp.Application.Appointments.UpdateAppointment
{
    public class UpdateAppointmentCommand : IQuery<Result<Guid>>
    {
        public Guid AppointmentId { get; set; }
        public Guid DoctorId { get; set; }
        public DateTime AppointmentDate { get; set; }
    }
}
