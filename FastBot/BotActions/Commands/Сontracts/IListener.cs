using FastBot.BotActions.Services;
using Telegram.Bot.Types;

namespace FastBot.BotActions.Commands.Сontracts;

public interface IListener
{
    CommandExecutorService ExecutorService { get; }
    void GetUpdate(Update update);
    Task GetUpdateAsync(Update update);
}