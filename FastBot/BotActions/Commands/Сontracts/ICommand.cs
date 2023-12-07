using Telegram.Bot;
using Telegram.Bot.Types;

namespace FastBot.BotActions.Commands.Сontracts;

public interface ICommand
{
    string Name { get; init; }
    void SetTelegramBotClient(TelegramBotClient client);
    Task ExecuteAsync(Update update);
}