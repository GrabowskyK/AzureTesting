namespace AzureTesting.Model
{
    public abstract class Event
    {
        public int Id { get; set; }
        public string Time { get; set; } = "";
        public Game Game { get; set; }
        public int GameId { get; set; }
        
        public Team Team { get; set; }
        public int TeamId { get; set; }
        
        public Player Player { get; set; }
        public int PlayerId { get; set; }
        

    }

    public class Goal : Event
    {
        public int? AssistId { get; set; }
        public Player? Assist { get; set; }
    }

    public class Penalty : Event
    {
        public PenaltyType PenaltyType { get; set; } 
        public float Minutes { get; set; } 

    }

    public enum PenaltyType
    {
        Crosscheck,
        Slashing,
        Bodycheck,
        Offside
    }
}
