using FastBot.Exceptions;
using Telegram.Bot.Types;

namespace FastBot.BotActions.Services;

public class UpdateDistributorService
{
    private Dictionary<long, CommandExecutorService> _executors = new Dictionary<long, CommandExecutorService>();

    public async Task DistributeUpdateAsync(Update update)
    {
        if (update.Message is null)
            throw new TelegramException("Message in update is null.");
        
        var executor = _executors.GetValueOrDefault(update.Message.Chat.Id);

        if (executor is not null)
        {
            await executor.GetUpdateAsync(update);
            return;
        }

        executor = new CommandExecutorService();
        _executors.Add(update.Message.Chat.Id, executor);
        await executor.GetUpdateAsync(update);
    }
}