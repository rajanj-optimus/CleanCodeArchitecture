using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyApp.Application.Commands;
using MyApp.Application.Query;
using MyApp.Core.Entities;

namespace MyApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        IMediator _mediator;
        public EmployeeController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        public async Task<IActionResult> AddEmployeeAsync([FromBody] EmployeeEntity employee)
        {
            var result = await _mediator.Send(new AddEmployeeCommand(employee.Name, employee.Email, employee.Phone) );
            return Ok(result);
        }
        [HttpGet("employees")]
        public async Task<IActionResult> GetActionResultAsync()
        {
            var result = await _mediator.Send(new GetAllEmployeesQuery());
            return Ok(result);
        }
        [HttpGet("employees/{Id:Guid}")]
        public async Task<IActionResult> GetEmployeeByIdAsync([FromRoute]Guid Id)
        {
            var result = await _mediator.Send(new GetEmployeeByIdQuery(Id));
            return Ok(result);
        }
        [HttpPut("employees/{Id:Guid}")]

        public async Task<IActionResult> UpdateEMployeeAsync([FromRoute] Guid Id, [FromBody] EmployeeEntity employee)
        {
            var result = await _mediator.Send(new UpdateEmployeeCommand(Id,employee));
            return Ok(result);
        }
        [HttpDelete("employees/{Id:Guid}")]

        public async Task<IActionResult> DeleteEMployeeAsync([FromRoute] Guid Id)
        {
            var result = await _mediator.Send(new DeleteEmployeeCommand(Id));
            return Ok(result);
        }
    }
}
