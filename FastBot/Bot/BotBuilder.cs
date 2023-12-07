using FastBot.BotActions.Commands.Сontracts;
using FastBot.Exceptions;
using Telegram.Bot;

namespace FastBot.Bot;

public class BotBuilder
{
    public Bot Bot => _bot;
    
    private Bot _bot;

    public BotBuilder(Bot bot)
    {
        _bot = bot;
    }
    
    public BotBuilder SetBotApiToken(string token)
    {
        if(string.IsNullOrEmpty(token))
            throw new BotBuildingException("The bot api key is null or empty.");
        
        _bot.BotApiKey = token;
        
        return this;
    }
    
    public BotBuilder SetBotName(string name)
    {
        if(string.IsNullOrEmpty(name))
            throw new BotBuildingException("The bot name is null or empty.");
        if (!string.IsNullOrEmpty(_bot.Name))
            throw new BotBuildingException("The bot name is already set.");
        _bot.Name = name;
        
        return this;
    }

    public BotBuilder UseLongPolling()
    {
        if (_bot.UseWebhooks)
            throw new BotBuildingException("Can not use long polling. Bot already use webhooks.");
        
        _bot.UseLongPolling = true;
        
        return this;
    }

    public BotBuilder UseWebhooks(/*string addressToListen*/)
    {
        if (_bot.UseLongPolling)
            throw new BotBuildingException("Can not use webhooks. Bot already use long polling.");
        // if (string.IsNullOrEmpty(addressToListen))
        //     throw new BotBuildingException("Can not use link for webhook: link is null or empty.");
        
        _bot.UseWebhooks = true;
        //_bot.WebhooksHttpsLink = addressToListen;
        
        return this;
    }

    public BotBuilder SetCommands(List<ICommand> commands)
    {
        if (commands is null)
            throw new BotBuildingException("Commands are null. Bot did not build.");
        if (string.IsNullOrEmpty(_bot.BotApiKey))
            throw new BotBuildingException("Bot Api Key should be set before commands. ");
        var botClient = new TelegramBotClient(_bot.BotApiKey);
        
        _bot.Commands = commands;
        
        foreach (var com in _bot.Commands)
            com.SetTelegramBotClient(botClient);

        return this;
    }

    public Bot Build()
    {
        if (_bot is  { UseWebhooks: false, UseLongPolling: false })
        {
            throw new BotBuildingException("Can not build bot. Webhooks or long polling are not assigned.");
        }
        return _bot;
    }

    public static implicit operator Bot(BotBuilder builder)
    {
        return builder.Bot;
    }
}