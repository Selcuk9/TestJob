using System.ComponentModel.DataAnnotations;

namespace TestJob.Entyties;

/// <summary>
/// Информацию о статусе запроса
/// </summary>
public class RequestStatus
{
    /// <summary>
    /// Идентификатор запроса
    /// </summary>
    public Guid Id { get; set; }
    /// <summary>
    /// Процент выполнения запроса
    /// </summary>
    [Required]
    public int Percent { get; set; }
    public UserStatistics UserStatistics { get; set; }
    [Required]
    public Guid UserStatisticsId { get; set; }
}