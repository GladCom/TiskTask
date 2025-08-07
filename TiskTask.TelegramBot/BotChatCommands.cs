using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiskTask.TelegramBot
{
  /// <summary>
  /// Список команд боту при передаче текстовым сообщением.
  /// </summary>
  public static class BotChatCommands
  {
    /// <summary>
    /// Начать взаимодействие с ботом.
    /// </summary>
    public const string Start = "/start";

    /// <summary>
    /// Остановить бота.
    /// </summary>
    public const string Stop = "/stop";

    /// <summary>
    /// Получить информацию о боте или пользователе.
    /// </summary>
    public const string Info = "/info";

    /// <summary>
    /// Общая команда для изменения данных.
    /// </summary>
    public const string Change = "/change";

    /// <summary>
    /// Перезапустить процесс.
    /// </summary>
    public const string Restart = "/restart";

    /// <summary>
    /// Начать действие (например, запуск генерации).
    /// </summary>
    public const string Go = "/go";

    /// <summary>
    /// Изменить имя.
    /// </summary>
    public const string ChangeName = "/changename";

    /// <summary>
    /// Изменить город.
    /// </summary>
    public const string ChangeCity = "/changecity";

    /// <summary>
    /// Изменить род деятельности.
    /// </summary>
    public const string ChangeWork = "/changework";

    /// <summary>
    /// Изменить хобби.
    /// </summary>
    public const string ChangeHobby = "/changehobby";

    /// <summary>
    /// Изменить интересы.
    /// </summary>
    public const string ChangeInterests = "/changeinterests";

    /// <summary>
    /// Сгенерировать пары для общения.
    /// </summary>
    public const string GeneratePairs = "/generatepairs";

    /// <summary>
    /// Отправить сгенерированные пары участникам.
    /// </summary>
    public const string SendPairs = "/sendpairs";

    /// <summary>
    /// Получить случайную пару для общения.
    /// </summary>
    public const string RandomPair = "/randompair";

    /// <summary>
    /// Создать новую сущность (например, событие).
    /// </summary>
    public const string Create = "/create";

    /// <summary>
    /// Показать все элементы (например, всех участников).
    /// </summary>
    public const string All = "/all";
  }
}
