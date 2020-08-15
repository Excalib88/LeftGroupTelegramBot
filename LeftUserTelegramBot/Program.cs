using System;
using System.IO;
using System.Threading;
using Microsoft.Extensions.Configuration;

namespace LeftUserTelegramBot
{
    class Program
    {
        static void Main(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();
                
            var token = configuration["Telegram:Token"];
            Console.WriteLine($"Бот с токеном {token} запущен");
            
            var botWorker = new BotWorker(token);
            botWorker.StartBot();

            Console.ReadKey();
            //Thread.Sleep(Timeout.Infinite);
        }
    }
}