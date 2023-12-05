using FastBot.Exceptions;
using Telegram.Bot;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;

namespace FastBot.BotActions.Services;

public class UpdatePollingDistributorService : IUpdateHandler
{
    private Dictionary<long, CommandExecutorService> _executors = new Dictionary<long, CommandExecutorService>();

    public UpdatePollingDistributorService()
    {
        
    }

    public async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
    {
        foreach (var i in _executors)
        {
            Console.WriteLine(i.Key  + ""+  i.Value);
        }

        // await botClient.SendTextMessageAsync(update.Message.Chat.Id, "lolo");
        if(update.Message.Text != "")
            await DistributeUpdateAsync(update);
    }

    public async Task HandlePollingErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
    {
        Console.WriteLine(exception.Message);
    }
    
    private async Task DistributeUpdateAsync(Update update)
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