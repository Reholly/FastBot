using FastBot.Exceptions;

namespace FastBot.Bot;

public class BotBuilder
{
    public Bot Bot { get; set; }
    private Bot _bot;

    public BotBuilder(Bot bot)
    {
        _bot = bot;
    }

    public BotBuilder SetBotConfiguration(BotConfiguration configuration)
    {
        if (configuration is null)
            throw new BotBuildingException("Configuration is null.");
        _bot.Configuration = configuration;

        return this;
    }

    public Bot Build()
    {
        return _bot;
    }

    public static implicit operator Bot(BotBuilder builder)
    {
        return builder.Bot;
    }
}