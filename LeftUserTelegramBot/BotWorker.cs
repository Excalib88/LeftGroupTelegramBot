using Telegram.Bot;
using Telegram.Bot.Args;

namespace LeftUserTelegramBot
{
    public class BotWorker
    {
        private static TelegramBotClient _bot;
        
        public BotWorker(string token)
        {
            _bot = new TelegramBotClient(token);
        }

        public void StartBot()
        {
            var isReceiving = _bot.IsReceiving;
            _bot.OnUpdate += OnUpdate;
            _bot.StartReceiving();
        }
        
        public async void OnUpdate(object sender, UpdateEventArgs e)
        {
            var chat = e.Update.Message.Chat;
            var leftUser = e.Update.Message.LeftChatMember;
            var message = e.Update.Message;
            
            if(chat == null || message == null) return;

            if (leftUser != null)
            {
                await _bot.SendTextMessageAsync(chat.Id, "https://music.yandex.ru/album/9791754/track/62244864"); 
            }

            if (!string.IsNullOrEmpty(message.Text))
            {
                switch(message.Text)
                {
                    case "Привет":
                    {
                        await _bot.SendTextMessageAsync(chat.Id, $"Привет {message.From.Id}");
                        break;
                    }
                }
            }
        }
    }
}