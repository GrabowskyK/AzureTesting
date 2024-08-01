using AzureTesting.DTO.Team;
using AzureTesting.Model;

namespace AzureTesting.Service.TeamServ
{
    public interface ITeamService
    {
        LeagueWithTeamsDTO? GetTeamsInLeague(int leagueId);
        IEnumerable<Team> GetTeams();
        void AddTeamAsync(AddTeamDTO newTeam, int leagueId, int? imageId);
    }
}