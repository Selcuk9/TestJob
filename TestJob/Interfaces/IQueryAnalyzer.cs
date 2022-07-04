using TestJob.Dto;
using TestJob.Entyties;

namespace TestJob.Interfaces;

public interface IQueryAnalyzer
{
    public void Start(RequestStatusDto requestId);
    public RequestStatusDto GetCurrentState(Guid id);
    public RequestStatusDto CreateRequest();
}