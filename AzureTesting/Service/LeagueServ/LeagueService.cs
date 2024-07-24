using AzureTesting.Database;
using AzureTesting.DTO.League;
using AzureTesting.Model;

namespace AzureTesting.Service.LeagueServ
{
    public class LeagueService : ILeagueService
    {
        private readonly DatabaseContext databaseContext;

        public LeagueService(DatabaseContext _databaseContext)
        {
            databaseContext = _databaseContext;
        }

        public void AddLeague(LeagueInfoDTO league, string? blobUrl)
        {
            Image image = new Image(blobUrl, league.Name);
        }
    }
}
