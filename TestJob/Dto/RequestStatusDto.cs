namespace TestJob.Dto;

/// <summary>
/// Информацию о статусе запроса
/// </summary>
public class RequestStatusDto
{
    /// <summary>
    /// Идентификатор запроса
    /// </summary>
    public Guid RequestId { get; set; }
    /// <summary>
    /// Процент выполнения запроса
    /// </summary>
    public int Percent { get; set; } 
    /// <summary>
    /// Результат выполнения
    /// </summary>
    public UserStatisticsDto? Result { get; set; }
}