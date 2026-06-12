using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiskTask.Core;

/// <summary>
/// Описывает модель задачи.
/// </summary>
public class UserTask
{
    #region Поля и свойства

    /// <summary>
    /// Идентификатор.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Идентификатор пользователя.
    /// </summary>
    public long UserId { get; set; }

    /// <summary>
    /// Название задачи.
    /// </summary>
    public string Title { get; set; }

    /// <summary>
    /// Описание задачи.
    /// </summary>
    public string Description { get; set; }

    /// <summary>
    /// Дата создания задачи.
    /// </summary>
    public DateTime Created { get; set; }

    /// <summary>
    /// Потраченное время на задачу.
    /// </summary>
    public TimeSpan TimeSpent { get; set; }

    #endregion

    #region Конструкторы

    public UserTask(int id, long userId, string title, string description, DateTime createdDate)
    {
        Id = id;
        UserId = userId;
        Title = title;
        Description = description;
        Created = createdDate;
        TimeSpent = TimeSpan.Zero;
    }

    public UserTask()
    {
        Id = -1;
        UserId = -1;
        Title = "None";
        Description = "None";
        Created = DateTime.Now;
        TimeSpent = TimeSpan.Zero;
    }
    #endregion

    public void Print()
    {
        Console.WriteLine($"{Id} {Title} ({Description})");
    }
}
