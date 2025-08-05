using Telegram.Bot;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

namespace TiskTask.TelegramBot
{
    public class TelegramBot
    {
        private readonly ITelegramBotClient _botClient;

        public TelegramBot(string botToken)
        {
            _botClient = new TelegramBotClient(botToken);
        }

        /// <summary>
        /// Запускает бота и начинает получать обновления.
        /// </summary>
        public async Task StartAsync(CancellationToken cancellationToken = default)
        {
            var me = await _botClient.GetMe();
            Console.WriteLine($"✅ Бот @{me.Username} запущен. Ожидание сообщений...");

            // Запускаем получение обновлений
            await _botClient.ReceiveAsync(
                updateHandler: new UpdateHandler(_botClient),
                cancellationToken: cancellationToken
            );
        }
    }

    /// <summary>
    /// Обработчик входящих обновлений от Telegram.
    /// </summary>
    internal class UpdateHandler : IUpdateHandler
    {
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

                if (text == "/start")
                {
                    await botClient.SendMessage(
                        chatId: chatId,
                        text: "Добро пожаловать!",
                        cancellationToken: cancellationToken
                    );
                    return;
                }

                if (message.Type == MessageType.Text && !string.IsNullOrEmpty(text))
                {
                    await botClient.SendMessage(
                        chatId: chatId,
                        text: $"📝 Вы написали: {text}",
                        cancellationToken: cancellationToken
                    );
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
}