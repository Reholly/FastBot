using FastBot.BotActions.Commands.Сontracts;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace FastBot.BotActions.Commands.SimpleCommands;

public class SimpleVideoCommand : ICommand
{
    public string Name { get; init; }

    private TelegramBotClient _client = null!;
    private string _uri;

    public SimpleVideoCommand(string name, string uri)
    {
        Name = name;
        _uri = uri;
    }
    
    public void SetTelegramBotClient(TelegramBotClient client)
    {
        _client = client;
    }

    public async Task ExecuteAsync(Update update)
    {
        await _client.SendVideoAsync(update.Message!.Chat.Id, InputFile.FromUri(_uri));
    }
}