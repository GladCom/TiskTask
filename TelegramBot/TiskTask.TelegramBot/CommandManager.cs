namespace TiskTask.TelegramBot;

public class CommandManager
{
    // Класс для представления задачи
    private static readonly TaskManager _taskManager = new TaskManager();
        
    /// <summary>
    /// Метод для обработки команды /all
    /// </summary>
    /// <param name="botClient">TG Bot API клиента.</param>
    /// <param name="chatId">Идентификатор чата.</param>
    /// <param name="cancellationToken">Прерывание запроса.</param>
    public static async Task TakeAllTasksCommand(ITelegramBotClient botClient, long chatId, CancellationToken cancellationToken)
    {
        var tasks = _taskManager.GetAllTasks();

        if (!tasks.Any())
        {
            await botClient.SendMessage(
                chatId: chatId,
                text: "Опаньки, а задач-то нет.",
                cancellationToken: cancellationToken
            );
            return;
        }
        foreach (var task in tasks)
        {
            string message = $"ID: {task.Id}\nЗаголовок: {task.Title}\nОписание: {task.Description}";
            await botClient.SendMessage(
                chatId: chatId,
                text: message,
                cancellationToken: cancellationToken
            );
        }
    }
}