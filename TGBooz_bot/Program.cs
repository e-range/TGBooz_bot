using static System.Runtime.InteropServices.JavaScript.JSType;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Polling;
using Telegram.Bot.Types.Enums;

// See https://aka.ms/new-console-template for more information

CancellationTokenSource cts = new CancellationTokenSource();

var bot = new TelegramBotClient("7647109657:AAHeU6yOJ6EjaDcUKNFUb6RVFzsbgMyLoPA", cancellationToken: cts.Token);
var me = await bot.GetMe();

bot.OnError += OnError;
bot.OnMessage += OnMessage;
bot.OnUpdate += OnUpdate;

Console.WriteLine($"@{me.Username} is running... Press Enter to terminate! =)");
Console.ReadLine();
cts.Cancel(); // stop the bot

async Task OnError(Exception exception, HandleErrorSource source)
{
    Console.WriteLine(exception);
}

async Task OnMessage(Message msg, UpdateType type)
{
    if (msg.Text == "/start") {
        await bot.SendMessage(msg.Chat, $"Hello!");
    }
}

async Task OnUpdate(Update update)
{
    if (update is { CallbackQuery: { } query }) {
    }
}