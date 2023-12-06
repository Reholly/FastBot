// See https://aka.ms/new-console-template for more information

using FastBot.Bot;
using FastBot.BotActions.Implementations;
using FastBot.BotActions.Сontracts;

/*
 * var registrationRoot = new Root("/register", new RegisterHandler());
 * registrationRoot.AddConditionEnding(new RegisterStopCondition(), new StopRegisterHandler());
 * retustrationRoot.AddEnding(new EndRegister());
 *
 * var script = Script.Create()
 *                  .AddRoot(registrationRoot);
 *                  .AddRoot(new StartRoot("/start").AddEnding(new Ending("Вот список команд: /start, register", SendMessage)));
 * OR
 *
 * var commandContainer = new CommandContainer();
 * commandContainer.Add(new Command("/start", new Handler(чета делает));
 * commandContainer.Add(new Command("хочу сасать", new Handler(чета делает));
 * commandContainer.Add(new Command("хачу яблок", new Handler(чета делает));
 *
 * var script = Script.Create()
 *                   .AddCommand("/start")
 *                   .AddConditionEnding( (x => x.Message =="stop"), "stop");
 *                   .AddEnding("/register);

 * var bot = Bot.Create()
 *           .SetToken("blablalbla)                                                                  
 *           .SetWebConfiguration(config =>
 *               config.SetProperties(new BotPropertiesBuilder()
 *                         .UseWebhooks("ngrokToken")  //UseLongPolling или тип такого
 *                         .UseUsersLimit(500) // количество чатов одновременно у пользователей
 *                         .Build())
 *           .SetScript(script);
 *           .Build(); 
 * 
 * await bot.RunAsync();
 * 
 */

var list = new List<ICommand>
{
    new StartCommand()
};

var bot = Bot.Create()
    .SetBotName("TestingLibraryCSUBot")
    .SetBotApiToken("6705659421:AAEHdWwkiAbUfrP-q1WoipLZM3QWMxnY5mA")
    .SetCommands(list)
    .UseWebhooks(/*"https://localhost:5274/"*/)
    .Build();

await bot.Run();
Console.WriteLine("бот запущен");



            