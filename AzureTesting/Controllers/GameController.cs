using AzureTesting.Service.GameServ;
using Microsoft.AspNetCore.Mvc;

namespace AzureTesting.Controllers
{
    public class GameController : ControllerBase
    {
        private readonly IGameService gameService;
        private readonly ILogger<GameController> logger;

        public GameController(IGameService gameService, ILogger<GameController> logger)
        {
            this.gameService = gameService;
            this.logger = logger;
        }

     
    }
}
