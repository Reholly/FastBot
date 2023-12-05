using FastBot.Exceptions;

namespace FastBot.Bot;

public class BotConfigurationBuilder
{
    private BotConfiguration Configuration { get; set; }
    
    public BotConfigurationBuilder(BotConfiguration botConfiguration)
    {
        Configuration = botConfiguration;
    }

    public BotConfigurationBuilder SetBotApiToken(string token)
    {
        if(string.IsNullOrEmpty(token))
            throw new BotBuildingException("The bot api key is null or empty.");
        
        Configuration.BotApiKey = token;
        
        return this;
    }
    
    public BotConfigurationBuilder SetBotName(string name)
    {
        if(string.IsNullOrEmpty(name))
            throw new BotBuildingException("The bot name is null or empty.");
        if (!string.IsNullOrEmpty(Configuration.Name))
            throw new BotBuildingException("The bot name is already set.");
        Configuration.Name = name;
        
        return this;
    }

    public BotConfigurationBuilder UseLongPolling()
    {
        if (Configuration.UseWebhooks)
            throw new BotConfigurationBuildingException("Can not use long polling. Bot already use webhooks.");
        
        Configuration.UseLongPolling = true;
        
        return this;
    }

    public BotConfigurationBuilder UseWebhooks(string httpsLink)
    {
        if (Configuration.UseLongPolling)
            throw new BotConfigurationBuildingException("Can not use webhooks. Bot already use long polling.");
        if (string.IsNullOrEmpty(httpsLink))
            throw new BotConfigurationBuildingException("Can not use link for webhook: link is null or empty.");
        
        Configuration.UseWebhooks = true;
        Configuration.WebhooksHttpsLink = httpsLink;
        
        return this;
    }

    public BotConfiguration Build()
    {
        return Configuration;
    }

    public static implicit operator BotConfiguration(BotConfigurationBuilder builder)
    {
        return builder.Configuration;
    }
}