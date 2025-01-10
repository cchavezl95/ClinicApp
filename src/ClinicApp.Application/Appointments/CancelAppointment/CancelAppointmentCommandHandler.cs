using ClinicApp.Application.Abstractions.CQRS;
using ClinicApp.Application.Appointments.CancelAppointment;
using ClinicApp.Domain.Abstractions;
using ClinicApp.Domain.Appointment;
using ClinicApp.Domain.Appointment.ValueObjects;
using MediatR;


namespace ClinicApp.Application.Appointments.ChangeStatusAppointment
{
    public class CancelAppointmentCommandHandler : IQueryHandler<CancelAppointmentCommand, Result<Guid>>
    {
        private readonly IAppointmentRepository _appointmentRepository;

        public CancelAppointmentCommandHandler(IAppointmentRepository appointmentRepository)
        {
            _appointmentRepository = appointmentRepository;
        }

        public async Task<Result<Guid>> Handle(CancelAppointmentCommand query, CancellationToken cancellationToken)
        {
            var appointment = await _appointmentRepository.GetByIdAsync(query.AppointmentId);

            if (appointment == null)
            {
                return Result.Failure<Guid>(AppointmentErros.NotFound); // O lanza una excepción según tu lógica
            }

            if (!appointment.Status.value)
            {
                return Result.Failure<Guid>(AppointmentErros.Canceled);
            }
            // Cambiar el estado de true a false
            appointment.UpdateStatus(new AppoinmentStatus(false));

            await _appointmentRepository.UpdateAsync(appointment);

            return query.AppointmentId;
        }
    }
}
