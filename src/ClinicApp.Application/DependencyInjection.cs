using ClinicApp.Application.Abstractions.CQRS;
using ClinicApp.Application.Appointments.Commands;
using ClinicApp.Application.Appointments.DTOs;
using Microsoft.Extensions.DependencyInjection;
using MediatR;
using ClinicApp.Application.Appointments.GetAppoinment;
using ClinicApp.Application.Appointments.CancelAppointment;
using ClinicApp.Application.Appointments.ChangeStatusAppointment;
using ClinicApp.Domain.Abstractions;
using ClinicApp.Application.Appointments.UpdateAppointment;
using ClinicApp.Application.Doctors.CreateDoctor;

namespace ClinicApp.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            // Registro de handlers de CQRS
            services.AddTransient<IQueryHandler<CreateAppointmentCommand, Result<Guid>>, CreateAppointmentCommandHandler>();
            services.AddTransient<IQueryHandler<GetAppointmentCommand, Result<AppointmentDTO>>, GetAppointmentCommandHandler>();
            services.AddTransient<IQueryHandler<CancelAppointmentCommand, Result<Guid>>, CancelAppointmentCommandHandler>();
            services.AddTransient<IQueryHandler<UpdateAppointmentCommand, Result<Guid>>, UpdateAppointmentCommandHandler>();
            services.AddTransient<IQueryHandler<CreateDoctorCommand, Result<Guid>>, CreateDoctorCommandHandler>();
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly));

            return services;
        }
    }
}
