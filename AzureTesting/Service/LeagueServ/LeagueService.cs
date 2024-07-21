using AzureTesting.Database;

namespace AzureTesting.Service.LeagueServ
{
    public class LeagueService : ILeagueService
    {
        private readonly DatabaseContext databaseContext;

        public LeagueService(DatabaseContext _databaseContext)
        {
            databaseContext = _databaseContext;
        }
    }
}
