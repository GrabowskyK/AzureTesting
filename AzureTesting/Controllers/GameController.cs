using AzureTesting.DTO;
using AzureTesting.DTO.Game;
using AzureTesting.Model;
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

        [HttpPost("AddGame")]
        public ActionResult<GameDTO> AddGame(GameDTO gameDTO)
        {
            gameService.AddGame(gameDTO);
            return Ok("Game has been added!");
        }

        [HttpGet("GetGames")]
        public ActionResult<GameDTO> GetGames(int? leagueId)
        {
            var result = gameService.GetGames(leagueId);
            return Ok(result);
        }

        [HttpGet("{gameId}")]
        public ActionResult<Game> GetSingleGame([FromRoute] int gameId)
        {
            var result = gameService.GetFullGame(gameId);
            return Ok(result);
        }

        [HttpDelete("DeleteGame")]
        public IActionResult DeleteGame(int gameId)
        {
            gameService.DeleteGame(gameId);
            return Ok("Game has been deleted!");
        }
    }
}
