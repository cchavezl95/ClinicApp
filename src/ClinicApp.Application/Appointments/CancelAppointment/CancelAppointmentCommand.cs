using ClinicApp.Application.Abstractions.CQRS;
using ClinicApp.Domain.Abstractions;

namespace ClinicApp.Application.Appointments.CancelAppointment
{
    public class CancelAppointmentCommand : IQuery<Result<Guid>>
    {
        public Guid AppointmentId { get; set; }
    }
}
