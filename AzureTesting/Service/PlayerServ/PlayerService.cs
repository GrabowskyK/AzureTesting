using AzureTesting.Database;
using AzureTesting.DTO.Player;
using AzureTesting.DTO.Team;
using AzureTesting.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AzureTesting.Service.PlayerServ
{
    public class PlayerService : IPlayerService
    {
        private readonly DatabaseContext databaseContext;
        public PlayerService(DatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }

        public async Task AddPlayers(List<PlayerBasicDTO> players, int teamId)
        {
            List<Player> playersList = new List<Player>();
            foreach (var player in players)
            {
                Player player1 = new Player(player.Name, player.Surname, teamId);
                playersList.Add(player1);
            }
            await databaseContext.Players.AddRangeAsync(playersList);
            await databaseContext.SaveChangesAsync();
        }

        public TeamWithPlayers? GetPlayersInTeam(int teamId) {
            var playersInTeam = databaseContext.Players.Where(p => p.TeamId == teamId).ToList();;
            var result = databaseContext.Players
            .Where(p => p.TeamId == teamId)
            .Select(t => new TeamWithPlayers()
            {
                League = new DTO.League.LeagueInfoDTO(t.team.League.Name, t.team.League.ShortName, t.team.League.Year)
                {
                    Id = t.team.LeagueId
                },

                Team = new TeamDTO(t.team.Name, t.team.ShortName)
                {
                    Id = t.team.Id,
                    BlobURL = t.team.Image.BlobUrl,
                    LeagueId = t.team.LeagueId
                },

                players = playersInTeam
            }).FirstOrDefault();
            return result;
        }

            
    }
}
