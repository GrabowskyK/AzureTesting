using AzureTesting.DTO.Player;
using AzureTesting.DTO.Team;

namespace AzureTesting.Service.PlayerServ
{
    public interface IPlayerService
    {
        Task AddPlayers(List<PlayerBasicDTO> players, int teamId);
        TeamWithPlayers GetPlayersInTeam(int teamId);
    }
}