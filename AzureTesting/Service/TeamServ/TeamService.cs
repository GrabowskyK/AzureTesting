using AzureTesting.Database;
using AzureTesting.DTO.Team;
using AzureTesting.Model;
using Microsoft.EntityFrameworkCore;

namespace AzureTesting.Service.TeamServ
{
    public class TeamService : ITeamService
    {
        private readonly DatabaseContext databaseContext;
        
        public TeamService(DatabaseContext _databaseContext)
        {
            databaseContext = _databaseContext;
        }

        public LeagueWithTeamsDTO? GetTeamsInLeague(int leagueId)
        {
            List<TeamDTO> teams = new List<TeamDTO>();
            teams = databaseContext.Teams.Where(t => t.LeagueId == leagueId).Select(t => new TeamDTO()
            {
                Id = t.Id,
                Name = t.Name,
                ShortName = t.ShortName,
                BlobURL = t.Image.BlobUrl
            }).ToList();
            return databaseContext.Leagues.Where(l => l.Id == leagueId)
            .Select(l => new LeagueWithTeamsDTO()
            {
                id = l.Id,
                Name = l.Name,
                ShortName = l.ShortName,
                Year = l.Year,
                BlobUrl = l.Image.BlobUrl,
                Teams = teams
            }).FirstOrDefault();
        }
    

        public void AddTeamAsync(AddTeamDTO newTeam, int leagueId, int? imageId)
        {
            Team team = new Team(newTeam.Name, newTeam.ShortName, leagueId, imageId);
            databaseContext.Teams.Add(team);
            databaseContext.SaveChanges();
        }

        public IEnumerable<Team> GetTeams() => databaseContext.Teams;
    }
}
