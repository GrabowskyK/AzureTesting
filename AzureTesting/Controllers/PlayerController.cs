using AzureTesting.DTO.Player;
using AzureTesting.DTO.Team;
using AzureTesting.Service.PlayerServ;
using Microsoft.AspNetCore.Mvc;

namespace AzureTesting.Controllers
{
    public class PlayerController : ControllerBase
    {
        private readonly IPlayerService playerService;
        private readonly ILogger<PlayerController> logger;

        public PlayerController(IPlayerService playerService, ILogger<PlayerController> logger)
        {
            this.playerService = playerService;
            this.logger = logger;
        }

        [HttpPost("{teamId}/AddPlayers")]
        public ActionResult<PlayerBasicDTO> AddPlayers([FromBody] List<PlayerBasicDTO> players, [FromRoute] int teamId)
        {
            try
            {
                playerService.AddPlayers(players, teamId);
                return Ok();
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message.ToString());
                return BadRequest("Something went wrong!");
            }
        }

        [HttpGet("{teamId}/GetPlayers")]
        public ActionResult<TeamWithPlayers> GetPlayer([FromRoute] int teamId)
        {
            try
            {
                var result = playerService.GetPlayersInTeam(teamId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message.ToString());
                return BadRequest("Something went wrong!");
            }
        }
    }
}
