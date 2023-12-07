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
<p><code>SimpleAudioCommand(string command, string uri)</code> - sending audio message in response of <code>command</code></p>
<p><code>SimplePictureCommand(string command, string uri)</code> - sending image message in response of <code>command</code></p>


<h1>Exceptions</h1>
<h1>Use in ASP projects</h1>


