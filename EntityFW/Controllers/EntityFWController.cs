using Microsoft.AspNetCore.Mvc;

namespace EntityFW.Controllers;

[ApiController]
[Route("[controller]")]
public class EntityFWController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<EntityFWController> _logger;

    public EntityFWController(ILogger<EntityFWController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    public IEnumerable<EntityFW> Get()
    {
        return Enumerable.Range(1, 5).Select(index => new EntityFW
        {
            Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        })
        .ToArray();
    }
}
