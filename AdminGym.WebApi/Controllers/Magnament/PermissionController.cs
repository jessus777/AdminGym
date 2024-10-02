using AdminGym.Application.Features.UserManagement.Commands.CreatePermission;
using AdminGym.Application.Features.UserManagement.Dtos;
using AdminGym.Application.Features.UserManagement.Queries.GetAllPermission;
using AdminGym.WebApi.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AdminGym.WebApi.Controllers.Magnament
{
    [Route("api/[controller]")]
    [ApiController]
    [Tags("Magnament: Permisos")]
    public class PermissionController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PermissionController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/<PermissionController>
        [HttpGet]
        public async Task<IActionResult> GetAllPermission(
            CancellationToken cancellationToken
            )
        {
            var result = await _mediator.Send(
                GetAllPermissionQuery.Instance,
                cancellationToken
                );

            return result.IsSuccess
               ? Ok(result.Value)
               : result.ToProblemDetails();
        }

        // GET api/<PermissionController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<PermissionController>
        [HttpPost]
        public async Task<IActionResult> Post(
            [FromBody] CreatePermissionDto permission,
            CancellationToken cancellationToken
            )
        {
            var result = await _mediator.Send(new CreatePermissionCommand(permission), cancellationToken);
            return result.IsSuccess
                ? Ok(result.Value)
                : result.ToProblemDetails();
        }

        // PUT api/<PermissionController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<PermissionController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
