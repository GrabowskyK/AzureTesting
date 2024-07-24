using AzureTesting.DTO.League;
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
        public IActionResult GetLeagues()
        {
            return Ok();
        }

        [HttpPost("AddLeague")]
        public IActionResult AddLeague(LeagueInfoDTO league, IFormFile file)
        {
            var blobUrl = blobService.AddBlobAsync(file);
          //  leagueService.AddBlobServiceClient()
            return Ok();
        }

        [HttpDelete("RemoveLeague")]
        public IActionResult RemoveLeague()
        {
            return Ok();
        }
    }
}
