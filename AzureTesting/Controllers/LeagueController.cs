using AzureTesting.DTO.League;
using AzureTesting.Model;
using AzureTesting.Service.BlobServ;
using AzureTesting.Service.LeagueServ;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Azure;
using System.Reflection.Metadata;

namespace AzureTesting.Controllers
{
    public class LeagueController : ControllerBase
    {
        private readonly ILeagueService leagueService;
        private readonly IBlobService blobService;
        private readonly ILogger<LeagueController> logger;

        public LeagueController(ILeagueService _leagueService, IBlobService _blobService, ILogger<LeagueController> _logger)
        {
            leagueService = _leagueService;
            blobService = _blobService;
            logger = _logger;
        }

        [HttpGet("GetLeagues")]
        public ActionResult<LeagueInfoDTO> GetLeagues()
        {
            var leagues = leagueService.GetLeagues();
            return Ok(leagues);
        }

        [HttpGet("LeagueById")]
        public ActionResult<League> GetLeagueById([FromRoute] int leagueId)
        {
            var league = leagueService.GetLeagueById(leagueId);
            if (league != null)
            {
                return Ok(league);
            }
            return BadRequest("League dosent exist!");
        }

        [HttpPost("AddLeague")]
        public IActionResult AddLeague([FromForm] CreateLeague createLeague)
        {
            string? blobUrl = null;
            if(createLeague.File == null)
            {
                blobUrl = null;
            }
            else
            {
                blobUrl = blobService.AddBlob(createLeague.File).ToString();
            }
            leagueService.AddLeague(createLeague, blobUrl);

            return Ok($"{createLeague.Name} has been added!");
        }

        [HttpDelete("RemoveLeague")]
        public IActionResult RemoveLeague(int leagueId)
        {
            try
            {
                leagueService.RemoveLeague(leagueId);
                return Ok("League has been deleted!");
            }
            catch (Exception ex)
            {
                logger.LogError(ex.ToString());
                return BadRequest("Something went wrong");
            }
        }

        [HttpPatch("UpdateLeague")]
        public ActionResult<CreateLeague> UpdateLeague(PatchLeague league,int editedLeagueId)
        {
            leagueService.PatchLeague(league, editedLeagueId);
            return Ok("League has been updated!");
        }
    }
}
