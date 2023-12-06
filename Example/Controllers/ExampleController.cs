using FastBot.Bot;
using FastBot.BotActions.Services;
using Microsoft.AspNetCore.Mvc;

using Telegram.Bot.Types;

namespace WebApplication1.Controllers;

[ApiController]
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