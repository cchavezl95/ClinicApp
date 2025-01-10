using ClinicApp.Application.Abstractions.CQRS;
using ClinicApp.Application.Appointments.DTOs;
using ClinicApp.Domain.Abstractions;

namespace ClinicApp.Application.Appointments.Commands
{
    public class CreateAppointmentCommand : IQuery<Result<Guid>>
    {
        public string PatientName { get; set; }
        public Guid DoctorId { get; set; }
        public DateTime AppointmentDate { get; set; }
    }
}
