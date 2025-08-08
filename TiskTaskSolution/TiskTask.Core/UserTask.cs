using System;

namespace TiskTask.Core;

/// <summary>
/// Описывает модель задачи.
/// </summary>
public partial class UserTask
{
    /// <summary>
    /// Идентификатор.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Идентификатор пользователя telegram.
    /// </summary>
    public int UserId { get; set; }

    /// <summary>
    /// Название задачи.
    /// </summary>
    public string Title { get; set; } = null!;

    /// <summary>
    /// Описание задачи.
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// Дата создания задачи.
    /// </summary>
    public string Created { get; set; } = null!;

    /// <summary>
    /// Потраченное время на задачу.
    /// </summary>
    public int? TimeSpent { get; set; }

    public UserTask(int id, int userId, string title, string description, DateTime createdDate)
    {
        Id = id;
        UserId = userId;
        Title = title;
        Description = description;
        Created = createdDate.ToString();
    }

    public UserTask()
    {
    }
}
