using FastBot.BotActions.Сontracts;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace FastBot.BotActions.Implementations;

public class StartCommand : ICommand
{
    public string Name { get; init; }

    private TelegramBotClient _client;

    public StartCommand()
    {
        _client = new TelegramBotClient("6705659421:AAEHdWwkiAbUfrP-q1WoipLZM3QWMxnY5mA");
        Name = "/start";
        
    }

    public StartCommand(string name)
    {
        Name = name;
    }
    
    public void SetTelegramBotClient(TelegramBotClient client)
    {
        _client = client;
    }

    public async Task ExecuteAsync(Update update)
    {
        await _client.SendTextMessageAsync(update.Message!.Chat.Id, "привет!");
    }
}