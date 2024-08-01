using AzureTesting.DTO.Team;
using AzureTesting.Model;
using AzureTesting.Service.BlobServ;
using AzureTesting.Service.ImageServ;
using AzureTesting.Service.TeamServ;
using Microsoft.AspNetCore.Mvc;

namespace AzureTesting.Controllers
{
    [ApiController]
    [Route("/Team")]
    public class TeamController : ControllerBase
    {
        private readonly ITeamService teamService;
        private readonly IBlobService blobService;
        private readonly ILogger<TeamController> logger;
        public TeamController(ILogger<TeamController> logger, ITeamService _teamService, IBlobService _blobService)
        {
            this.logger = logger;
            teamService = _teamService;
            blobService = _blobService;
        }
        [HttpGet("{leagueId}")]
        
        public ActionResult<TeamDTO> GetTeamsInLeague(int leagueId)
        {
            var result = teamService.GetTeamsInLeague(leagueId);
            return Ok(result);
        }

        [HttpPost("{leagueId}/AddTeam")]
        public ActionResult<Team> AddTeam(AddTeamDTO newTeam, [FromRoute] int leagueId)
        {
            Image? imageObject = null;
            if (newTeam.image != null)
            {
                var blobUrl = blobService.AddBlob(newTeam.image).Result;
                blobService.SaveImageAsync(blobUrl, newTeam.image.FileName);
                imageObject = blobService.GetSingleImageByUrl(blobUrl);
            }

            try
            {
                teamService.AddTeamAsync(newTeam, leagueId, imageObject != null ? imageObject.Id : null);
                return Ok("Team has been added!");
            }
            catch (Exception ex)
            {
                logger.LogError(ex.ToString());
                return BadRequest("Something went wrong!");
            }
        }

        [HttpGet("GetTeams")]
        public ActionResult<Team> GetTeams()
        {
            return Ok(teamService.GetTeams());
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
