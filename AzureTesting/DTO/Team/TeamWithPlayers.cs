using AzureTesting.DTO.League;
using AzureTesting.Model;

namespace AzureTesting.DTO.Team
{
    public class TeamWithPlayers
    {
        public LeagueInfoDTO League { get; set; }
        public TeamDTO Team { get; set; }
        public List<Model.Player> players { get; set; }

    }
}
