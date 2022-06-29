using Microsoft.AspNetCore.Mvc;
using TestJob.Dto;

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
    public async Task<ActionResult<Guid>> GetUserStatics([FromBody] Guid userId)
    {
        return Ok(Guid.NewGuid());
    }

    [HttpGet("info")]
    public async Task<ActionResult<RequestStatusDto>> GetRequestInfo()
    {
        return Ok(new RequestStatusDto());
    } 
}