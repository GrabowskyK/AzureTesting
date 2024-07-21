using AzureTesting.Database;
using AzureTesting.DTO.Team;
using AzureTesting.Model;

namespace AzureTesting.Service.TeamServ
{
    public class TeamService : ITeamService
    {
        private readonly DatabaseContext databaseContext;
        
        public TeamService(DatabaseContext _databaseContext)
        {
            databaseContext = _databaseContext;
        }

        public IEnumerable<TeamDTO> GetTeamsInLeague(int leagueId) => databaseContext.Teams.Where(t => t.LeagueId == leagueId)
            .Select(t => new TeamDTO()
            {
                Id = t.Id,
                Name = t.Name,
                ShortName = t.ShortName,
                ImageId = t.ImageId != null ? t.ImageId : null
            });

        public async Task AddTeamAsync(Team team)
        {
            databaseContext.Teams.Add(team);
            await databaseContext.SaveChangesAsync();
        }
    }
}
