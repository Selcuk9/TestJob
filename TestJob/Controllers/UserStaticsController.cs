using Microsoft.AspNetCore.Mvc;

namespace TestJob.Controllers;


[Route("api/report")]
[ApiController]
public class UserStaticsController : Controller
{
    private ILogger<UserStaticsController> _logger;

    public UserStaticsController(ILogger<UserStaticsController> logger)
    {
        _logger = logger;
    }

    [HttpPost("user_statistics")]
    public Task<ActionResult> GetUserStatics([FromBody] Guid userId)
    {
        
    }
    
    public Task<>
}