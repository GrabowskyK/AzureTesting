namespace AzureTesting.Model
{
    public class Game
    {
        public int Id { get; set; }
        public Team TeamA { get; set; }
        public int TeamAID { get; set; }
        public Team TeamB { get; set; }
        public int TeamBID { get; set; }
        public int ScoreTeamA { get; set; }
        public int ScoreTeamB { get; set; }
        public string Date { get; set; }
        public string City { get; set; }
        public string Place { get; set; }
        public bool IsFinished { get; set; } = false;


    }
}
