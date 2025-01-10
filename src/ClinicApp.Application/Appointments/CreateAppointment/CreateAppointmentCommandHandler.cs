using ClinicApp.Application.Abstractions.CQRS;
using ClinicApp.Domain.Abstractions;
using ClinicApp.Domain.Appointment;
using ClinicApp.Domain.Appointment.ValueObjects;
using ClinicApp.Domain.Doctor;
using ClinicApp.Domain.Shared;

namespace ClinicApp.Application.Appointments.Commands
{
    public class CreateAppointmentCommandHandler : IQueryHandler<CreateAppointmentCommand, Result<Guid>>
    {
        private readonly IAppointmentRepository _appointmentRepository;
        private readonly IDoctorRepository _doctorRepository;

        public CreateAppointmentCommandHandler(IAppointmentRepository appointmentRepository,IDoctorRepository doctorRepository)
        {
            _appointmentRepository = appointmentRepository;
            _doctorRepository = doctorRepository;
        }

        public async Task<Result<Guid>> Handle(CreateAppointmentCommand command, CancellationToken cancellationToken)
        {
            var doctor = await _doctorRepository.GetByIdAsync(command.DoctorId);

            if (doctor == null)
            {
                return Result.Failure<Guid>(DoctorErros.NotFound); // O lanza una excepción según tu lógica
            }

            var appointment = Appointment.Reserve(command.DoctorId, new Name(command.PatientName), new AppointmentDate(command.AppointmentDate));

            await _appointmentRepository.AddAsync(appointment);

            return appointment.Id;
        }
    }
}
