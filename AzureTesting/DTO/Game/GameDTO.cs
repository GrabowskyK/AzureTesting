using AzureTesting.DTO.Team;
using AzureTesting.Migrations;
using Microsoft.Identity.Client;

namespace AzureTesting.DTO.Game
{
    public class GameDTO
    {
        //There is question what is better... collect the ids or collect Object of teamdto and then send it from front. Or get the
        // ids and create query to get this teams.
        public int Id { get; set; }
        public int TeamAid { get; set; }
        public int TeamBid { get; set; }
        public TeamDTO? TeamA { get; set; }
        public TeamDTO? TeamB { get; set; }
        public int ScoreTeamA { get; set; } = 0;
        public int ScoreTeamB { get; set; } = 0;
        public string Date { get; set; } = DateTime.Now.ToString();
        public string City { get; set; }
        public string Place { get; set; }

        public GameDTO() { }
        public GameDTO(string date, string city, string place)
        {
            Date = date;
            City = city;
            Place = place;
        }
    }
}
