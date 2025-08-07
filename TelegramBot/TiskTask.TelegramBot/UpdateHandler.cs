using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot.Polling;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types;
using Telegram.Bot;

namespace TiskTask.TelegramBot
{
  /// <summary>
  /// Обработчик входящих обновлений от Telegram.
  /// </summary>
  internal class UpdateHandler : IUpdateHandler
  {
    /// <summary>
    /// Создание клиента для работы с Телеграм ботом.
    /// </summary>
    private readonly ITelegramBotClient _botClient;

    public UpdateHandler(ITelegramBotClient botClient)
    {
      _botClient = botClient;
    }

    public async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
    {
      try
      {
        if (update.Message is not Message message) return;

        var chatId = message.Chat.Id;

        var text = message.Text;

        Console.WriteLine($"📩 От {message.From.FirstName}: {text ?? "[не текст]"}");

        if (message.Type == MessageType.Text && !string.IsNullOrEmpty(text))
        {
          if (text == BotChatCommands.Start)
          {
          await botClient.SendMessage(
              chatId: chatId,
              text: "Добро пожаловать!",
              cancellationToken: cancellationToken
          );
          return;
          }
          else if (text == BotChatCommands.All) 
          {
            await CommandManager.TakeAllTasksCommand(botClient, chatId, cancellationToken);
          }
        }
        else
        {
          await botClient.SendMessage(
            chatId: chatId,
            text: "Я могу обрабатывать только текстовые сообщения.",
            cancellationToken: cancellationToken
          );
        }
      }
      catch (Exception ex)
      {
        Console.WriteLine($"❌ Ошибка при обработке сообщения: {ex.Message}");
      }
    }

    public Task HandleErrorAsync(ITelegramBotClient botClient, Exception exception, HandleErrorSource source, CancellationToken cancellationToken)
    {
      throw new NotImplementedException();
    }
  }

  /// <summary>
  /// Список команд боту при передаче текстовым сообщением.
  /// </summary>
  public class BotChatCommands
  {
    public const string Start = "/start";
    public const string Stop = "/stop";
    public const string Info = "/info";
    public const string Change = "/change";
    public const string Restart = "/restart";
    public const string Go = "/go";
    public const string ChangeName = "/changename";
    public const string ChangeCity = "/changecity";
    public const string ChangeWork = "/changework";
    public const string ChangeHobby = "/changehobby";
    public const string ChangeInterests = "/changeinterests";
    public const string GeneratePairs = "/generatepairs";
    public const string SendPairs = "/sendpairs";
    public const string RandomPair = "/randompair";
    public const string Create = "/create";
    public const string All = "/all";
  }
}
