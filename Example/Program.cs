using FastBot.Bot;
using FastBot.BotActions.Commands.SimpleCommands;
using FastBot.BotActions.Commands.Сontracts;
using FastBot.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddControllers().AddNewtonsoftJson();

var list = new List<ICommand>
{
    new SimplePictureCommand("/picture", "https://gas-kvas.com/grafic/uploads/posts/2023-10/1696422775_gas-kvas-com-p-kartinki-milie-kotyat-12.jpg"),
    new SimpleMessageCommand("/start", "привет! можешь посмотреть мои команды с помощью /help"),
    new SimpleMessageCommand("/hello", "привет! меня зовут тестовый робот!"),
    new SimpleMessageCommand("/bottown", "мой город: Челябинск. "),
    new SimpleMessageCommand("/help", "Мои команды: /hello, /start, /help, Узнать больше, /pain"),
    new SimpleMessageCommand("Узнать больше", "Бла бла бла бла бла бльше инфы бла бла бла."),
    new SimpleMessageCommand("/pain", "Ты не найдешь работу нормальным программистом и пойдешь работать на PHP. ")
};

builder.Services.AddBot(Bot.Create()
    .SetBotName("TestingLibraryCSUBot")
    .SetBotApiToken("YOUR_API_KEY")
    .SetCommands(list)
    .UseWebhooks()
    .Build());
    
var app = builder.Build();

app.MapControllers();

app.Run();