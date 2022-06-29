namespace TestJob.Dto;

/// <summary>
/// Статистика пользователя
/// </summary>
public class UserStaticsDto
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