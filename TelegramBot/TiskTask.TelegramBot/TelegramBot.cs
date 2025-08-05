using System;
using System.Threading;
using System.Threading.Tasks;

using Telegram.Bot;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

namespace TiskTask.TelegramBot
{
    public class TelegramBot
    {
        /// <summary>
        /// Создание клиента для работы с Телеграм ботом.
        /// </summary>
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
            /// <summary>
            /// Запрос информации о боте.
            /// </summary>
            var me = await _botClient.GetMe();

            Console.WriteLine($"Бот @{me.Username} запущен. Ожидание сообщений...");

            // Запускаем получение обновлений
            await _botClient.ReceiveAsync(
                updateHandler: new UpdateHandler(_botClient),
                cancellationToken: cancellationToken
            );
        }
    }
}