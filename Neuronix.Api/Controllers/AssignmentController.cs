using Microsoft.AspNetCore.Mvc;

namespace Neuronix.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class AssignmentController : ControllerBase
{
    private readonly ILogger<AssignmentController> _logger;

    public AssignmentController(ILogger<AssignmentController> logger)
    {
        _logger = logger;
    }
    
    [HttpGet()]
    public IEnumerable<WeatherForecast> Get()
    {
        return null;
    }
    
}