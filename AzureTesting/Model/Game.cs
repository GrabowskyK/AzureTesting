namespace AzureTesting.Model
{
    public class Game
    {
        public int Id { get; set; }
        public Team TeamA { get; set; }
        public int TeamAID { get; set; }
        public Team TeamB { get; set; } 
        public int TeamBID { get; set; }
        public int ScoreTeamA { get; set; } = 0;
        public int ScoreTeamB { get; set; } = 0;
        public string Date { get; set; } = DateTime.Now.ToString();
        public string City { get; set; } 
        public string Place { get; set; }
        public bool IsFinished { get; set; } = false;
        //public Refree Refree { get; set; }
        //public int? RefreeId { get; set; } = null;
        
        public Game() { }
        public Game(int teamAID, int teamBID, string date, string city, string place)
        {
            TeamAID = teamAID;
            TeamBID = teamBID;
            Date = date;
            City = city;
            Place = place;
        }
    }
}
