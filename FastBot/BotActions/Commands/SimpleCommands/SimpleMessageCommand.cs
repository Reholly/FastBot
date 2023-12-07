using FastBot.BotActions.Commands.Сontracts;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace FastBot.BotActions.Commands.SimpleCommands;

public class SimpleMessageCommand : ICommand
{
    public string Name { get; init; }

    private string _message;
    private TelegramBotClient _client = null!;

    public SimpleMessageCommand(string name, string message)
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