using AzureTesting.DTO.League;
using AzureTesting.DTO.Player;

namespace AzureTesting.DTO.Game
{
    public class GameDetailsDTO
    {
        public int Id { get; set; }
        public GameDTO Game { get; set; }
        public LeagueInfoDTO League { get; set; }
        public List<PlayerBasicDTO> PlayersTeamA { get; set; }
        public List<PlayerBasicDTO> PlayersTeamB { get; set; }
    }
}
