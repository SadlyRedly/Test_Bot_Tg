using System;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types.ReplyMarkups;

namespace Bot_TG_Test
{
    class Class1
    {
        private static string token { get; set; } = "5429885234:AAHYG9o63AX-G6gdXWYaZBIMdI370mwAoIQ";
        private static TelegramBotClient client;

        static void Main(string[] args)
        {
            client = new TelegramBotClient(token);
            client.StartReceiving();
            client.OnMessage += OnMessageHandler;
            Console.ReadLine();
            client.StopReceiving();
        }

        private static async void OnMessageHandler(object sender, MessageEventArgs e)
        {
            var msg = e.Message;
            if (msg.Text != null)
            {
                Console.WriteLine($"Пришло сообщение: {msg.Text}");
                switch (msg.Text)
                {
                    case "Стикер":
                        var stic = await client.SendStickerAsync(
                            chatId: msg.Chat.Id,
                            sticker: "https://chpic.su/_data/stickers/j/James_Deen_stickers/James_Deen_stickers_010.webp",
                            replyToMessageId: msg.MessageId,
                            replyMarkup: GetButtons());
                        break;

                    case "Картинка":
                        var pic = await client.SendPhotoAsync(
                            chatId: msg.Chat.Id,
                            photo: "https://sun9-west.userapi.com/sun9-56/s/v1/if1/Z2rSa_umCaul3xkootflMfUzmWGu43xHfH-T6D9_1K8oLKwrmZ9cqP7Qj_eqoI6XYZ-QJCL0.jpg?size=813x1080&quality=96&type=album",
                            replyToMessageId: msg.MessageId,
                            replyMarkup: GetButtons());
                        break;

                        default:
                        await client.SendTextMessageAsync(msg.Chat.Id, "Пшёл вон отсюдова", replyMarkup: GetButtons());
                        break;
                }
            }
        }

        private static IReplyMarkup GetButtons()
        {

            return new ReplyKeyboardMarkup
            {
                Keyboard = new List<List<KeyboardButton>>
                {
                    new List<KeyboardButton>{ new KeyboardButton { Text = "Стикер"},  new KeyboardButton { Text = "Картинка" } },
                    new List<KeyboardButton>{ new KeyboardButton { Text = "Саша крут!"},  new KeyboardButton { Text = "Даня крут!" } }
                }
            };
        }
    }
}