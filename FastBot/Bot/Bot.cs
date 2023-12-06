using System.Net;
using FastBot.BotActions.Services;
using FastBot.BotActions.Сontracts;
using Telegram.Bot;
using Telegram.Bot.Types;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace FastBot.Bot;

public class Bot
{
    public string Name { get; set; } = string.Empty;
    public string BotApiKey { get; set; } = string.Empty;
    public bool UseWebhooks { get; set; }
    public bool UseLongPolling { get; set; }
    public string WebhooksHttpsLink { get; set; } = string.Empty;
    public List<ICommand> Commands { get; set; } = null!;
    
    private TelegramBotClient? _botClient;
    private CancellationTokenSource _cancellationTokenSource = null!;
    private UpdateDistributorService _updateDistributorService;

    public static BotBuilder Create()
    {
        return new BotBuilder(new Bot());
    }
    
    public async Task Run()
    {
        Console.WriteLine("run");
        _updateDistributorService = new UpdateDistributorService(Commands);

        HttpListener listener = new HttpListener();
        listener.Prefixes.Add(WebhooksHttpsLink);
        listener.Start();
        Console.WriteLine("start listen");
        
        while (true)
        {
        var context = await listener.GetContextAsync();
        var request = context.Request;
            Console.WriteLine("l");
            Console.WriteLine(request.HttpMethod);
            if (request.HttpMethod == "Post")
            {
                Console.WriteLine("post");
                request.InputStream.Position = 0;
                var rawRequestBody = new StreamReader(request.InputStream).ReadToEnd();
                Update? update = JsonSerializer.Deserialize<Update>(rawRequestBody);

                if (update is not null)
                {
                    _updateDistributorService.DistributeUpdateAsync(update);
                }
                
            }

            
            context.Response.StatusCode = 200;
        }


    }

    public UpdateDistributorService GetUpdateDistributor()
    {
        return new UpdateDistributorService(Commands);
    }
}