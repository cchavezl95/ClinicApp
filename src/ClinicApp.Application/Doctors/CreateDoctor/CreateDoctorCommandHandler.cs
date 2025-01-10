using ClinicApp.Domain.Abstractions;
using ClinicApp.Domain.Appointment.ValueObjects;
using ClinicApp.Domain.Appointment;
using ClinicApp.Domain.Doctor;
using ClinicApp.Domain.Shared;
using ClinicApp.Application.Abstractions.CQRS;

namespace ClinicApp.Application.Doctors.CreateDoctor
{
    public class CreateDoctorCommandHandler : IQueryHandler<CreateDoctorCommand, Result<Guid>>
    {
        private readonly IDoctorRepository _repository;

        public CreateDoctorCommandHandler(IDoctorRepository repository) { 
            _repository = repository;
        }

        public async Task<Result<Guid>> Handle(CreateDoctorCommand command, CancellationToken cancellationToken) { 
            
            var id = new Guid();

            var doctor = new Doctor(
                id,
                new Name(command.DoctorName)
            );

            await _repository.AddAsync(doctor);

            return doctor.Id;


        }
    }
}
