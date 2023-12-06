using FastBot.BotActions.Сontracts;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace WebApplication1.Commands;

public class ExampleCommand : ICommand
{
    public string Name { get; init; }
    
    private TelegramBotClient _client;
    private string _message = string.Empty;

    public ExampleCommand(string name, string message)
    {
        Name = name;
        _message = message;
    }

    public void SetTelegramBotClient(TelegramBotClient client)
    {
        _client = client;
    }

    public async Task ExecuteAsync(Update update)
    {
        await _client.SendTextMessageAsync(update.Message!.Chat.Id, _message);
    }
}