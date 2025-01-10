using ClinicApp.Application.Abstractions.CQRS;
using ClinicApp.Domain.Abstractions;
using ClinicApp.Domain.Appointment;
using ClinicApp.Domain.Appointment.ValueObjects;
using ClinicApp.Domain.Doctor;
using ClinicApp.Domain.Shared;
namespace ClinicApp.Application.Appointments.UpdateAppointment
{
    public class UpdateAppointmentCommandHandler : IQueryHandler<UpdateAppointmentCommand, Result<Guid>>
    {
        private readonly IAppointmentRepository _appointmentRepository;
        private readonly IDoctorRepository _doctorRepository;

        public UpdateAppointmentCommandHandler(IAppointmentRepository appointmentRepository,IDoctorRepository doctorRepository)
        {
            _appointmentRepository = appointmentRepository;
            _doctorRepository = doctorRepository;
        }

        public async Task<Result<Guid>> Handle(UpdateAppointmentCommand command, CancellationToken cancellationToken)
        {
            var doctor = await _doctorRepository.GetByIdAsync(command.DoctorId);

            if (doctor == null)
            {
                return Result.Failure<Guid>(DoctorErros.NotFound); // O lanza una excepción según tu lógica
            }

            var appointment = await _appointmentRepository.GetByIdAsync(command.AppointmentId);

            if (appointment == null)
            {
                return Result.Failure<Guid>(AppointmentErros.NotFound); // O lanza una excepción según tu lógica
            }

            if (!appointment.Status.value)
            {
                return Result.Failure<Guid>(AppointmentErros.Canceled);
            }

            if (appointment.Date.Date >= command.AppointmentDate )
            {
                return Result.Failure<Guid>(AppointmentErros.DateError); // O lanza una excepción según tu lógica
            }

            // Cambiar el estado de true a false
            appointment.UpdateAppointmentDate(new AppointmentDate(command.AppointmentDate));

            await _appointmentRepository.UpdateAsync(appointment);

            return command.AppointmentId;
        }
    }
}
