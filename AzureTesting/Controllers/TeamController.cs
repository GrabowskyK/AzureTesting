using AzureTesting.DTO.Team;
using AzureTesting.Model;
using AzureTesting.Service.TeamServ;
using Microsoft.AspNetCore.Mvc;

namespace AzureTesting.Controllers
{
    [ApiController]
    [Route("/Team")]
    public class TeamController : ControllerBase
    {
        private readonly ITeamService teamService;
        private readonly ILogger<TeamController> logger;
        public TeamController(ILogger<TeamController> logger, ITeamService _teamService)
        {
            this.logger = logger;
            teamService = _teamService;
        }
        [HttpGet("{leagueId}")]
        
        public ActionResult<TeamDTO> GetTeamsInLeague(int leagueId)
        {
            var result = teamService.GetTeamsInLeague(leagueId);
            return Ok();
        }

        [HttpPost("AddTeam")]
        public ActionResult<Team> AddTeam(Team team)
        {
            try
            {
                teamService.AddTeamAsync(team);
                return Ok("Team has been added!");
            }
            catch (Exception ex)
            {
                logger.LogError(ex.ToString());
                return BadRequest("Something went wrong!");
            }
        }

        [HttpDelete]
        public IActionResult RemoveTeam()
        {
            return Ok();
        }

        [HttpPatch]
        public IActionResult UpdateTeam()
        {
            return Ok();
        }

        
    }
}
