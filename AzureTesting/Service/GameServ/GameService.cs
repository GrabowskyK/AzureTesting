using AzureTesting.Database;
using AzureTesting.DTO.Game;
using AzureTesting.DTO.Player;
using AzureTesting.DTO.Team;
using AzureTesting.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AzureTesting.Service.GameServ
{
    public class GameService : IGameService
    {
        private readonly DatabaseContext databaseContext;
        public GameService(DatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }

        //Async method wont add record to database
        public void AddGame(GameDTO gameDTO)
        {
            Game game = new Game(gameDTO.TeamAid, gameDTO.TeamBid, gameDTO.Date, gameDTO.City, gameDTO.Place);
            databaseContext.Games.Add(game);
            databaseContext.SaveChanges();
        }

        public GameDetailsDTO GetFullGame(int gameId) 
        {
            GameDetailsDTO game = new GameDetailsDTO();
            game.Game = databaseContext.Games.Where(g => g.Id == gameId)
                .Include(g => g.TeamA)
                .Include(g => g.TeamB)
                .Select(g => new GameDTO()
                {
                    Id = g.Id,
                    TeamAid = g.TeamAID,
                    TeamBid = g.TeamBID,
                    ScoreTeamA = g.ScoreTeamA,
                    ScoreTeamB = g.ScoreTeamB,
                    Date = g.Date,
                    City = g.City,
                    Place = g.Place,
                    TeamA = new TeamDTO(g.TeamA.Name, g.TeamA.ShortName)
                    {
                        Id = g.TeamAID,
                        BlobURL = g.TeamA.Image.BlobUrl,
                        LeagueId = g.TeamA.LeagueId
                    },
                    TeamB = new TeamDTO(g.TeamB.Name, g.TeamB.ShortName)
                    {
                        Id = g.TeamBID,
                        BlobURL = g.TeamB.Image.BlobUrl,
                        LeagueId = g.TeamA.LeagueId
                    }
                }).First();

            game.PlayersTeamA = databaseContext.Players.Where(p => p.TeamId == game.Game.TeamAid)
                .Select(p => new PlayerBasicDTO(p.Id, p.Name, p.Surname, p.ShirtNumber))
                .AsEnumerable()
                .OrderBy(p => p.ShirtNumber).ToList();
            game.PlayersTeamB = databaseContext.Players.Where(p => p.TeamId == game.Game.TeamBid)
                .Select(p => new PlayerBasicDTO(p.Id, p.Name, p.Surname, p.ShirtNumber))
                .AsEnumerable()
                .OrderBy(p => p.ShirtNumber).ToList();
            return game;
        }

        public IEnumerable<GameDTO> GetGames(int? leagueId) 
        {
            var games = databaseContext.Games.Select(g => new GameDTO()
            {
                Id = g.Id,
                TeamAid = g.TeamAID,
                TeamBid = g.TeamBID,
                TeamA = new DTO.Team.TeamDTO(g.TeamA.Name, g.TeamA.ShortName)
                {
                    BlobURL = g.TeamA.Image.BlobUrl,
                    LeagueId = g.TeamA.LeagueId
                },
                TeamB = new DTO.Team.TeamDTO(g.TeamB.Name, g.TeamB.ShortName)
                {
                    BlobURL = g.TeamB.Image.BlobUrl,
                    LeagueId = g.TeamB.LeagueId
                },
                ScoreTeamA = g.ScoreTeamA,
                ScoreTeamB = g.ScoreTeamB,
                Date = g.Date,
                City = g.City,
                Place = g.Place
            });

            if(leagueId != null)
            {
                games = games.Where(g => g.TeamA.LeagueId == leagueId);
            }
            return games;
        }

        public async Task DeleteGame(int gameId)
        {
            var game = databaseContext.Games.Find(gameId);
            databaseContext.Games.Remove(game!);
            await databaseContext.SaveChangesAsync();
        }
            
    }
}
