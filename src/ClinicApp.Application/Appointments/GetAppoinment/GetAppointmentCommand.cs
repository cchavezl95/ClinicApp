using ClinicApp.Application.Abstractions.CQRS;
using ClinicApp.Application.Appointments.DTOs;
using ClinicApp.Domain.Abstractions;

namespace ClinicApp.Application.Appointments.GetAppoinment
{
    public class GetAppointmentCommand : IQuery<Result<AppointmentDTO>>
    {
        public Guid AppointmentId { get; set; }
    }
}
