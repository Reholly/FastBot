using FastBot.BotActions.Commands.Сontracts;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace FastBot.BotActions.Commands.SimpleCommands;

public class SimpleAudioCommand : ICommand
{
    public string Name { get; init; }

    private TelegramBotClient _client = null!;
    private readonly string _uri;

    public SimpleAudioCommand(string name, string uri)
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
        await _client.SendAudioAsync(update.Message!.Chat.Id, InputFile.FromUri(_uri));
    }
}