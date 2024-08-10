using AzureTesting.Database;
using AzureTesting.DTO.Game;
using AzureTesting.Model;
using Microsoft.AspNetCore.Mvc;

namespace AzureTesting.Service.GameServ
{
    public interface IGameService
    {
        void AddGame(GameDTO gameDTO);
        IEnumerable<GameDTO> GetGames(int? leagueId);
        GameDetailsDTO GetFullGame(int gameId);
        Task DeleteGame(int gameId);
    }
}