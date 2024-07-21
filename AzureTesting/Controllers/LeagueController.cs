using AzureTesting.Service.LeagueServ;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace AzureTesting.Controllers
{
    public class LeagueController : ControllerBase
    {
        private readonly ILeagueService leagueService;
        private readonly ILogger<LeagueController> logger;

        public LeagueController(ILeagueService _leagueService, ILogger<LeagueController> _logger)
        {
            leagueService = _leagueService;
            logger = _logger;
        }

        [HttpGet("GetLeagues")]
        public IActionResult GetLeagues()
        {
            return Ok();
        }

        [HttpPost("AddLeague")]
        public IActionResult AddLeague()
        {
            return Ok();
        }

        [HttpDelete("RemoveLeague")]
        public IActionResult RemoveLeague()
        {
            return Ok();
        }
    }
}
