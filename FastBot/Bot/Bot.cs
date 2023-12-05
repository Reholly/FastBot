using FastBot.BotActions.Services;
using FastBot.BotActions.Сontracts;
using Telegram.Bot;

namespace FastBot.Bot;

public class Bot
{
    public BotConfiguration Configuration { get; set; } = null!;

    private TelegramBotClient? _botClient;
    private CancellationTokenSource _cancellationTokenSource = null!;

    public void Run()
    {
        _cancellationTokenSource = new();
        InitializeBotClientIfNull();
        
        if (Configuration.UseLongPolling)
        {
                     
            Console.WriteLine("СТарт лонг поллинга");
            var polling = new UpdatePollingDistributorService();
            while (true)
            {
                _botClient!.ReceiveAsync(polling, cancellationToken:_cancellationTokenSource.Token);
            }
        }
    }

    public void Stop()
    {
        _cancellationTokenSource.Cancel();
    }

    public void AddCommand(ICommand command)
    {
        InitializeBotClientIfNull();
        command.SetTelegramBotClient(_botClient!);
    }
    public static BotBuilder Create()
    {
        return new BotBuilder(new Bot());
    }

    private void InitializeBotClientIfNull()
    {
        _botClient ??= new TelegramBotClient(Configuration.BotApiKey);
    }
}