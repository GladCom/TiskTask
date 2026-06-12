using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace TiskTask.Core;

/// <summary>
/// Класс для работы с задачами пользователя
/// </summary>
public class UserTaskManager
{
    #region Поля и свойства

    /// <summary>
    /// Список задач пользователей
    /// </summary>
    private readonly UserTaskFileStorage _tasks = new UserTaskFileStorage("tasks.csv");
    public List<UserTask> UsersTasks { get; set; } = new List<UserTask>();
    public Stopwatch Timer;

    #endregion

    #region Конструкторы
    public UserTaskManager()
    {
        UsersTasks = _tasks.Load();
        Timer = new Stopwatch();
    }

    #endregion

    #region Методы
    public UserTask CreateUserTask(int id, long userId, string title, string description, DateTime createDate)
    {
        var newUserTask = new UserTask(id, userId, title, description, createDate);
        UsersTasks.Add(newUserTask);
        _tasks.Save(UsersTasks);
        return newUserTask;
    }

    public bool ChangeUserTask(UserTask userTask)
    {
        var existingTask = UsersTasks.FirstOrDefault(t => t.Id == userTask.Id);
        if (existingTask == null)
        {
            return false;
        }
        existingTask.UserId = userTask.UserId;
        existingTask.Title = userTask.Title;
        existingTask.Description = userTask.Description;
        existingTask.Created = userTask.Created;

        _tasks.Save(UsersTasks);

        return true;
    }

    public bool DeleteUserTask(int id)
    {
        var removableTask = UsersTasks.FirstOrDefault(t => t.Id == id);
        if (removableTask == null)
        {
            return false;
        }
        UsersTasks.Remove(removableTask);
        _tasks.Save(UsersTasks);
        return true;
    }

    public List<UserTask> GetAllUserTasks(long userId)
    {
        return UsersTasks
            .Where(t => t.UserId == userId)  
            .ToList();
    }

    public UserTask GetUserTaskById(int taskId)
    {
        var gettingTask = UsersTasks.FirstOrDefault(t => t.Id == taskId);
        if (gettingTask == null)
            throw new KeyNotFoundException($"Задача с Id {taskId} не найдена.");

        return gettingTask;
    }

    #endregion

    public void Dispose()
    {
        _tasks.Save(UsersTasks);
    }
}

/// <summary>
/// класс счетчика
/// </summary>
public class Stopwatch
{
    private DateTime _startTime;
    private bool _isRunning;

    public DateTime StartTime
    {
        get
        {
            if (!_isRunning)
                throw new InvalidOperationException("Таймер не запущен");
            return _startTime;
        }
    }

    public Stopwatch()
    {
        _isRunning = false;
    }

    public void Start()
    {
        _startTime = DateTime.Now;
        _isRunning = true;
    }

    public TimeSpan Stop() //при остановке считает разницу и выводить
    {
        if (!_isRunning)
            throw new InvalidOperationException("Таймер не запущен");

        TimeSpan elapsedTime = DateTime.Now - StartTime;
        _isRunning = false;

        string timeData = $"{(int)elapsedTime.TotalHours:00} ч. {elapsedTime.Minutes:00} м. {elapsedTime.Seconds:00} с. {elapsedTime.Milliseconds:000} мс.";
        Console.WriteLine($"Время выполнения: {timeData}");
        return elapsedTime;
    }

    public TimeSpan GetCurrentElapsed()
    {
        if (!_isRunning)
            return TimeSpan.Zero;

        return DateTime.Now - _startTime;
    }
}
