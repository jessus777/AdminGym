using AdminGym.Application.Features.UserManagement.Commands.CreateRole;
using AdminGym.Application.Features.UserManagement.Dtos;
using AdminGym.WebApi.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AdminGym.WebApi.Controllers.Magnament;
[Route("api/[controller]")]
[ApiController]
[Tags("Magnament: Roles")]
public class RoleController : ControllerBase
{
    private readonly IMediator _mediator;

    public RoleController(IMediator mediator)
    {
        _mediator = mediator;
    }

    // GET: api/<RoleController>
    [HttpGet]
    public IEnumerable<string> Get()
    {
        return new string[] { "value1", "value2" };
    }

    // GET api/<RoleController>/5
    [HttpGet("{id}")]
    public string Get(int id)
    {
        return "value";
    }

    // POST api/<RoleController>
    [HttpPost]
    public async Task<IActionResult> CreateRole(
        [FromBody] CreateRoleDto role,
        CancellationToken cancellationToken
        )
    {
        var result = await _mediator.Send(new CreateRoleCommand(role), cancellationToken);
        return result.IsSuccess
            ? Ok(result.Value)
            : result.ToProblemDetails();
    }

    // PUT api/<RoleController>/5
    [HttpPut("{id}")]
    public void Put(int id, [FromBody] string value)
    {
    }

    // DELETE api/<RoleController>/5
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
    }
}
