using FastBot.Bot;
using FastBot.BotActions.Implementations;
using FastBot.BotActions.Services;
using FastBot.BotActions.Сontracts;
using WebApplication1.Commands;

namespace WebApplication1;

public class MyBot
{
    public Bot Bot => _bot;

    private Bot _bot; 
    
    public MyBot()
    {
        var list = new List<ICommand>
        {
            new StartCommand(),
            new ExampleCommand("/hello", "привет! меня зовут тестовый робот!"),
            new ExampleCommand("/bottown", "мой город: Челябинск. "),
            new ExampleCommand("/help", "Мои команды: /hello, /start, /help, Узнать больше"),
            new ExampleCommand("Узнать больше", "Бла бла бла бла бла бльше инфы бла бла бла ")
        };
        
        var bot = Bot.Create()
            .SetBotName("TestingLibraryCSUBot")
            .SetBotApiToken("6705659421:AAEHdWwkiAbUfrP-q1WoipLZM3QWMxnY5mA")
            .SetCommands(list)
            .UseWebhooks()
            .Build();

        _bot = bot;
    }
}