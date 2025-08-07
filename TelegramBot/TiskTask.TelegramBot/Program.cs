using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using TiskTask.TelegramBot;

namespace TiskTask.TelegramBot
{
  /// <summary>
  /// Консольное приложение для запуска Телеграм бота.
  /// </summary>
  class Program
  {
    static async Task Main(string[] args)
    {
      while (true)
      {
        Console.WriteLine("Запуск Telegram-бота...");

        var cts = new CancellationTokenSource();

        string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "token.txt");
        FileInfo fileInfo = new FileInfo(filePath);
        string readerFile = "";

        try
        {
          if (File.Exists(filePath))
          {
            using (StreamReader reader = fileInfo.OpenText())
            {
              readerFile = reader.ReadLine();
            }
          }
          else
          {
            Console.WriteLine("Файл не найден.");
            File.Create(filePath).Close();
            Console.Write("Файл создан автоматически по пути ");
            Console.Write(fileInfo + "\n");
            Console.WriteLine("Введите токен для вашего телеграм бота: ");
            readerFile = Console.ReadLine();

            using (StreamWriter writer = fileInfo.AppendText())
            {
              writer.WriteLine(readerFile);
            }
          }
        }
        catch (Exception ex)
        {
          Console.WriteLine("Ошибка при чтении файла: " + ex.Message);
        }

        try
        {
          var botService = new TelegramBot(readerFile);

          await botService.StartAsync(cts.Token);
        }
        catch (Exception ex)
        {
          Console.WriteLine("Ошибка при чтении файла: " + ex.Message);
          Console.WriteLine("Вы ввели не правильный токен, приложение будет перезапущено, " +
            "введите токен правильно");
          File.Delete(filePath);
        }

        Console.WriteLine("Бот остановлен.\n");
      }
    }
  }
}
