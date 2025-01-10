using ClinicApp.Application.Abstractions.CQRS;
using ClinicApp.Application.Doctors.CreateDoctor;
using ClinicApp.Domain.Abstractions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClinicApp.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private readonly IQueryHandler<CreateDoctorCommand, Result<Guid>> _queryHandler;

        public DoctorController(IQueryHandler<CreateDoctorCommand, Result<Guid>> queryHandler) { 
            _queryHandler = queryHandler;
        }

        [HttpPost]
        public async Task<IActionResult> CreateDoctor([FromBody] CreateDoctorCommand create) {
            var res = await _queryHandler.Handle(create,default);
            return Ok(res);
        }
    }
}
