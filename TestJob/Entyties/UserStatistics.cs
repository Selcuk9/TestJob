namespace TestJob.Entyties;

/// <summary>
/// Статистика пользователя
/// </summary>
public class UserStatistics
{
    /// <summary>
    /// Идентификатор пользователя
    /// </summary>
    public Guid Id { get; set; }
    /// <summary>
    /// Кол-во входов
    /// </summary>
    public int CountSignIn { get; set; }
    public ICollection<RequestStatus> RequestStatuses { get; set; }
}