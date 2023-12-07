using FastBot.BotActions.Commands.Сontracts;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace FastBot.BotActions.Commands.SimpleCommands;

public class SimplePictureCommand : ICommand
{
    public string Name { get; init; }

    private TelegramBotClient _client = null!;
    private readonly string _pictureUri;

    public SimplePictureCommand(string name, string pictureUri)
    {
        Name = name;
        _pictureUri = pictureUri;
    }
    
    public void SetTelegramBotClient(TelegramBotClient client)
    {
        _client = client;
    }

    public async Task ExecuteAsync(Update update)
    {
        await _client.SendPhotoAsync(update.Message!.Chat.Id, InputFile.FromUri(_pictureUri));
    }
}