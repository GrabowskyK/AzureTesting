using AzureTesting.DTO.League;
using AzureTesting.Model;

namespace AzureTesting.Service.LeagueServ
{
    public interface ILeagueService
    {
        IEnumerable<LeagueInfoDTO> GetLeagues();
        void AddLeague(CreateLeague createLeague, string? blobUrl);
        void RemoveLeague(int leagueId);
        void PatchLeague(PatchLeague patched, int editedLeagueId);
        League? GetLeagueById(int id);


    }
}