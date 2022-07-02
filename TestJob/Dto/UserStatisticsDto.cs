namespace TestJob.Dto;

/// <summary>
/// Статистика пользователя
/// </summary>
public class UserStatisticsDto
{
    /// <summary>
    /// Идентификатор пользователя
    /// </summary>
    public Guid UserId { get; set; }
    /// <summary>
    /// Кол-во входов
    /// </summary>
    public int CountSignIn { get; set; }
}