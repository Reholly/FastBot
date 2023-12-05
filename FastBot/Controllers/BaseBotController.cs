using FastBot.BotActions.Services;
using Microsoft.AspNetCore.Mvc;
using Telegram.Bot.Types;

namespace FastBot.Controllers;

internal class BaseBotController : ControllerBase
{
    private readonly UpdateDistributorService _updateDistributorService = new UpdateDistributorService();

    public async Task GetUpdate(Update update)
    {
        await _updateDistributorService.DistributeUpdateAsync(update);
    }
}