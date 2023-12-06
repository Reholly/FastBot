using Microsoft.Extensions.DependencyInjection;

namespace FastBot.Extensions;

public static class AddBotExtension
{
    public static void AddBot(this IServiceCollection collection, Bot.Bot bot)
    {
        collection.AddSingleton(bot);
    }
}