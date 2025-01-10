using ClinicApp.Application.Abstractions.CQRS;
using ClinicApp.Application.Appointments.DTOs;
using ClinicApp.Domain.Abstractions;
using ClinicApp.Domain.Appointment;

namespace ClinicApp.Application.Appointments.GetAppoinment
{
    public class GetAppointmentCommandHandler : IQueryHandler<GetAppointmentCommand, Result<AppointmentDTO>>
    {
        private readonly IAppointmentRepository _appointmentRepository;

        public GetAppointmentCommandHandler(IAppointmentRepository appointmentRepository)
        {
            _appointmentRepository = appointmentRepository;
        }

        public async Task<Result<AppointmentDTO>> Handle(GetAppointmentCommand query, CancellationToken cancellationToken)
        {
            var appointment = await _appointmentRepository.GetByIdAsync(query.AppointmentId);

            if (appointment == null)
            {
                return Result.Failure<AppointmentDTO>(AppointmentErros.NotFound); // O lanza una excepción según tu lógica
            }

            var dto = new AppointmentDTO
            {
                Id = appointment.Id,
                PatientName = appointment.PatientName.value,
                DoctorName = appointment.DoctorId,
                AppointmentDate = appointment.Date.Date,
                AppointmentStatus = appointment.Status.value
            };

            return Result.Success<AppointmentDTO>(dto);
        }
    }
}
