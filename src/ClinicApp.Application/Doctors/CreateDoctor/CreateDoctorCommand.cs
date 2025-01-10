using ClinicApp.Application.Abstractions.CQRS;
using ClinicApp.Domain.Abstractions;

namespace ClinicApp.Application.Doctors.CreateDoctor
{
    public class CreateDoctorCommand : IQuery<Result<Guid>>
    {
        public string DoctorName { get; set; }
    }
}
