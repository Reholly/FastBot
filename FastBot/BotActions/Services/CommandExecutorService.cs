using FastBot.BotActions.Commands.Сontracts;
using Telegram.Bot.Types;

namespace FastBot.BotActions.Services;

public class CommandExecutorService 
{
    private List<ICommand> _commands;
    private IListener? _currentListener;

    public CommandExecutorService(List<ICommand> commands)
    {
        _commands = commands;
    }
    
    public async Task GetUpdateAsync(Update update)
    {
        if (_currentListener is null)
            await ExecuteCommandAsync(update);
        else
            await _currentListener.GetUpdateAsync(update);
    }

    public void StartListen(IListener listener)
    {
        _currentListener = listener;
    }
    
    
    public void StopListen()
    {
        _currentListener = null;
    }

    private async Task ExecuteCommandAsync(Update update)
    {
        foreach(var command in _commands)
            if(command.Name == update.Message?.Text)
                await command.ExecuteAsync(update);
    }
    public List<ICommand> GetCommandsFromAssembly()
    {
        var types = AppDomain
            .CurrentDomain
            .GetAssemblies()
            .SelectMany(assembly => assembly.GetTypes())
            .Where(type => typeof(ICommand).IsAssignableFrom(type))
            .Where(type => type.IsClass);

        List<ICommand> commands = new List<ICommand>();
        
        foreach(var type in types)
        {
            ICommand? command;
            if(typeof(IListener).IsAssignableFrom(type))
                command = Activator.CreateInstance(type, this) as ICommand;
            else
                command = Activator.CreateInstance(type) as ICommand;
            

            if(command != null)
                commands.Add(command);
            
        }
        return commands;
    }
}