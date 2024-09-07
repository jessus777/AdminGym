using AdminGym.Application.Features.UserManagement.Commands.CreateUser;
using AdminGym.Application.Features.UserManagement.Dtos;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AdminGym.WebApi.Controllers;
[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{

    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<WeatherForecastController> _logger;
    private readonly IMediator _mediator;

    

    public WeatherForecastController(ILogger<WeatherForecastController> logger, IMediator mediator)
    {
        _logger = logger;
        _mediator = mediator;
    }

    [HttpGet(Name = "GetWeatherForecast")]
    public IEnumerable<WeatherForecast> Get()
    {
        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        {
            Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        })
        .ToArray();
    }

    [HttpPost]
  
    public async Task<IActionResult> CreateUser(
        [FromBody] CreateUserCommandDto user,
        CancellationToken cancellationToken
        )
    {
        var result = await _mediator.Send(new CreateUserCommand(user), cancellationToken);
        return result.IsSuccess
            ? Ok(result.Value)
            : result.ToProblemDetails();
    }
}
