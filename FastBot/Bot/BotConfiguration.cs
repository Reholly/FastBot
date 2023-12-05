namespace FastBot.Bot;

public class BotConfiguration
{
    public string Name { get; set; } = string.Empty;
    public string BotApiKey { get; set; } = string.Empty;
    public bool UseWebhooks { get; set; }
    public bool UseLongPolling { get; set; }
    public string WebhooksHttpsLink { get; set; } = string.Empty;

    public static BotConfigurationBuilder Create()
    {
        return new BotConfigurationBuilder(new BotConfiguration());
    }
}