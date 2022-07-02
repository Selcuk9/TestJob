using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestJob.Contexts;
using TestJob.Dto;
using TestJob.Entyties;
using TestJob.Interfaces;

namespace TestJob.Controllers;


[Route("api/report")]
[ApiController]
public class UserStaticsController : Controller
{
    private ILogger<UserStaticsController> _logger;
    private UserStatisticsContext _dbContext;
    private IConfigManager _configManager;

    public UserStaticsController(ILogger<UserStaticsController> logger, IConfigManager configManager, UserStatisticsContext dbContext)
    {
        _logger = logger;
        _configManager = configManager;
        _dbContext = dbContext;
    }

    [HttpPost("user_statistics")]
    public async Task<ActionResult<Guid>> GetUserStatics([FromBody] Guid userId)
    {
        _dbContext.RequestStatuses.Add(new RequestStatus()
        {
            Id = Guid.NewGuid(),
            Percent = 0,
            UserStatisticsId = userId
        });
        return Ok(Guid.NewGuid());
    }

    [HttpGet("info")]
    public async Task<ActionResult<RequestStatusDto>> GetRequestInfo()
    {
        return Ok(new RequestStatusDto());
    } 
}