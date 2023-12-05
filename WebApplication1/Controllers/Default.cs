using FastBot.BotActions.Services;
using Microsoft.AspNetCore.Mvc;
using Telegram.Bot.Types;

namespace WebApplication1.Controllers;

[ApiController]
public class Default : Controller
{
    private readonly UpdateDistributorService _updateDistributorService = new UpdateDistributorService();
    
    [HttpGet("/bot")]
    public void Get()
    {
        
    }

    [HttpPost("/bot")]
    public async Task Post(Update update)
    {
        await _updateDistributorService.DistributeUpdateAsync(update);
    }
}