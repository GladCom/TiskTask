using TiskTask.TelegramBot;

Console.WriteLine("Запуск Telegram-бота...");

var cts = new CancellationTokenSource();

// 🔐 Замени на свой токен
const string BotToken = "---";

var botService = new TelegramBot(BotToken);

// Запускаем бота
await botService.StartAsync(cts.Token);

Console.WriteLine("Бот остановлен.");