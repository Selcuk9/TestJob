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
    private IConfigManager _configManager;
    private IQueryAnalyzer _queryAnalyzer;

    public UserStaticsController(ILogger<UserStaticsController> logger, IConfigManager configManager, IQueryAnalyzer queryAnalyzer)
    {
        _logger = logger;
        _configManager = configManager;
        _queryAnalyzer = queryAnalyzer;
    }

    [HttpPost("user_statistics")]
    public async Task<ActionResult<Guid>> GetUserStatics([FromBody] Guid userId)
    {
        var request = _queryAnalyzer.CreateRequest();
        _queryAnalyzer.Start(request);
        return Ok(request.RequestId);
    }

    [HttpGet("info")]
    public async Task<ActionResult<RequestStatusDto>> GetRequestInfo([FromBody] Guid requestId)
    {
       return _queryAnalyzer.GetCurrentState(requestId);
    } 
}