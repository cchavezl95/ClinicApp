using ClinicApp.Application.Abstractions.CQRS;
using ClinicApp.Application.Appointments.CancelAppointment;
using ClinicApp.Application.Appointments.Commands;
using ClinicApp.Application.Appointments.DTOs;
using ClinicApp.Application.Appointments.GetAppoinment;
using ClinicApp.Application.Appointments.UpdateAppointment;
using ClinicApp.Domain.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace ClinicApp.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class AppointmentsController : ControllerBase
    {
        private readonly IQueryHandler<CreateAppointmentCommand, Result<Guid>> _createAppointmentHandler;
        private readonly IQueryHandler<GetAppointmentCommand, Result<AppointmentDTO>> _getAppointmentHandler;
        private readonly IQueryHandler<CancelAppointmentCommand, Result<Guid>> _cancelAppointmentHandler;
        private readonly IQueryHandler<UpdateAppointmentCommand, Result<Guid>> _updateAppointmentHandler;

        public AppointmentsController(IQueryHandler<CreateAppointmentCommand, Result<Guid>> createAppointmentHandler, IQueryHandler<GetAppointmentCommand, Result<AppointmentDTO>> getAppointmentByIdHandler, IQueryHandler<CancelAppointmentCommand, Result<Guid>> cancelAppointmentByIdHandler, IQueryHandler<UpdateAppointmentCommand, Result<Guid>> updateAppointmentByIdHandler)
        {
            _createAppointmentHandler = createAppointmentHandler;
            _getAppointmentHandler = getAppointmentByIdHandler;
            _cancelAppointmentHandler = cancelAppointmentByIdHandler;
            _updateAppointmentHandler = updateAppointmentByIdHandler;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAppointmentById(Guid id)
        {
            var query = new GetAppointmentCommand { AppointmentId = id };
            var result = await _getAppointmentHandler.Handle(query, default);

            return Ok(result);
        }

       
        [HttpPost]
        public async Task<IActionResult> CreateAppointment([FromBody] CreateAppointmentCommand command)
        {
            var res = await _createAppointmentHandler.Handle(command, default);
            return Ok(res);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> CancelAppointmentById(Guid id)
        {
            var query = new CancelAppointmentCommand { AppointmentId = id };
            var result = await _cancelAppointmentHandler.Handle(query, default);

            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAppointmentById([FromBody] UpdateAppointmentCommand command)
        {
            var result = await _updateAppointmentHandler.Handle(command, default);

            return Ok(result);
        }

    }
}
