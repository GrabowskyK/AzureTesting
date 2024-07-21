using AzureTesting.DTO.Team;
using AzureTesting.Model;

namespace AzureTesting.Service.TeamServ
{
    public interface ITeamService
    {
        IEnumerable<TeamDTO> GetTeamsInLeague(int leagueId);
        Task AddTeamAsync(Team team);
    }
}