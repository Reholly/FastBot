<h1 align="center" > Hi there, this is a little library for Telegram Bots on</h1>
<p align= "center"><img height="128" width="128" src="https://unpkg.com/simple-icons@v10/icons/dotnet.svg"/></p>
<h1 align="center" > FastBot </h1>

<p> Advantages:</p>
<p> - You can do your bot faster with FastBot</p>
<p> - Library using Telegram.Bot for already done parts: Update-model, TelegramBotClient</p>
<p> - This library is consistent</p>
<p> - Uses webhooks</p>
<p> - Encapsulate all logic inside and you could write only high-level commands</p>

<h1>Documentation</h1>

<p>Here is documentation for working with FastBot. You also may check Example Project. </p>

<h1>Bot</h1>
<p> To create a Bot, you need to use BotBuilder. You can create it step by step with this handy builder. First you need to call the Bot.Create(), after which you can assign the following: 
<p>- SetBotName() - to specify the name of the Bot inside the project </p>
<p> - SetBotApiToken() - to specify the telegram API token  </p>
<p> - SetCommands() - to specify the List of commands (see below about commands)   </p>
<p> - UseWebhooks - to indicate the use of webhooks  </p>

<p> After all the configuration of the Bot, you can create it using another method - Build()

<h1>Commands</h1>
<p> Ready-made FastBot commands are available in a large number of commands for the bot. The commands are divided into simple and composite ones. For example, you can simply add a reply message in response to some command by adding a <code> new SimpleMessageCommand("/your_command", "your message");</code></p>
<p>Each simple command implements the ICommand interface. The library contains some ready-made commands, but the user can also create their own by simply implementing the desired interface.</p>

<p>Here are examples of ready-made simple commands: </p>
<p><code>SimpleMessageCommand(string command, string message)</code> - sending text message in response of <code>command</code></p>
<p><code>SimpleAudioCommand(string command, string uri)</code> - sending audio message in response of <code>command</code> by uri</p>
<p><code>SimplePictureCommand(string command, string uri)</code> - sending image message in response of <code>command</code> by uri</p>

<p>Composite commands implement the IListener interface. Classes implementing this interface contain <code>CommandExecutorService</code> to communicate with the current chat and can also accept Update. In the implementation of the IListener interface, the class must also implement ICommand in order to be added as a command.</p>

<p>Here are examples of ready-made composite commands: </p>
<p><code> Oopps, there is nothing...</code></p>

<h1>Exceptions</h1>
<p>In project we have 2 types of Exceptions:</p>
<p><code>BotBuildingException</code> - appears if there are some error or conflicts in building <code>Bot</code>. As example, you may catch it if you did not set UseWebhooks or did not set BotApiKey</p>
<p><code>TelegramException</code> - appears if there are some error with Telegram. For example, you may catch it while update distributing by <code>UpdateDistributorService</code></p>

<h1>Use in ASP projects</h1>

For using in ASP projects you should do four steps:
<p>1) Create Controller with <code>UpdateDistributorService</code> dependency like:
<p><code>[ApiController]
public class ExampleController : Controller
{
    private readonly UpdateDistributorService _updateDistributorService;

    public ExampleController(Bot bot)
    {
        _updateDistributorService = bot.GetUpdateDistributor();
    }

    [HttpPost("/")]
    public async Task Post(Update update)
    {
        await _updateDistributorService.DistributeUpdateAsync(update);
    }
}
</code></p>
</p>
<p>2) You should create HttpPost method in controller that takes requests from your Webhook</p>
<p>3) Call <code>UpdateDistributor</code> method <code>DistributeUpdateAsync</code> for accepting updates.</p>
<p>4) Register your bot as dependency in <code>Startup</code> or <code>Program</code> by using extension method for IServiceCollection <code>AddBot</code></p>
