using ClinicApp.Domain.Abstractions;

namespace ClinicApp.Domain.Appointment.Events
{
    public class AppointmentCreatedDomainEvent : IDomainEvent
    {
        public Guid AppointmentId { get; }
        public DateTime OccurredOn { get; }

        public AppointmentCreatedDomainEvent(Guid appointmentId)
        {
            AppointmentId = appointmentId;
            OccurredOn = DateTime.UtcNow;
        }
    }
}
