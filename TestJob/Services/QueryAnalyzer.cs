using System.Timers;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using TestJob.Contexts;
using TestJob.Dto;
using TestJob.Entyties;
using TestJob.Interfaces;
using Timer = System.Threading.Timer;

namespace TestJob.Services;

public class QueryAnalyzer : IQueryAnalyzer
{
    // private readonly System.Timers.Timer _timer;
    private readonly IMemoryCache _memoryCache;
    private readonly UserStatisticsContext _dbcontext;
    private readonly IConfigManager _configManager;
    private readonly IMapper _mapper;
    private int seconds = 1;

    public QueryAnalyzer(IMemoryCache memoryCache, IConfigManager configManager,
        UserStatisticsContext statisticsContext, IMapper mapper)
    {
        _memoryCache = memoryCache;
        _configManager = configManager;
        _dbcontext = statisticsContext;
        _mapper = mapper;
    }

    public void Start(RequestStatusDto request)
    {
        int minRequestTime = _configManager.GetMinimumRequestTime();
        _memoryCache.Set(request.RequestId, new RequestStatus());
        TimerCallback func = async state =>
        {
            Console.WriteLine("Текущее время:  " + DateTime.Now.ToLongTimeString());
            var percent = (int)((double)seconds / minRequestTime * 100);
            var requestStatus = _dbcontext.RequestStatuses.First(rs => rs.Id == request.RequestId);
            requestStatus.Percent = percent;
            _dbcontext.RequestStatuses.Update(requestStatus);
            await _dbcontext.SaveChangesAsync();
            if (percent == 100)
            {
                return;
            }

            _memoryCache.Set(request.RequestId, new RequestStatus()
            {
                Id = request.RequestId,
                Percent = (int) percent,
            });
            seconds++;
        };
        Timer time = new Timer(func, null, TimeSpan.Zero, TimeSpan.FromSeconds(120));
    }

    public RequestStatusDto GetCurrentState(Guid id)
    {
        return new RequestStatusDto();  
    }

    public RequestStatusDto CreateRequest() => new()
    {
        RequestId = Guid.NewGuid(),
        Percent = 0,
        Result = null
    };

    private async Task CreateRequest(RequestStatusDto request)
    {
        var requestEntity = _mapper.Map<RequestStatus>(request);
        await _dbcontext.RequestStatuses.AddAsync(requestEntity);
    } 
}