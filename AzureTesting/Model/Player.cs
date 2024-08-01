namespace AzureTesting.Model
{
    public class Player
    {
        public int Id { get; set; }
        public string Name { get; set; } 
        public string Surname { get; set; }
        public string Born { get; set; } = DateTime.Now.ToString();

        public int ShirtNumber { get; set; } = 0;
        public Position? position { get; set; } = Position.Attack;
        public int Goals { get; set; } = 0;
        public int Assists { get; set; } = 0;
        public int Penalties { get; set; } = 0;
        public int MinutesPenalties { get; set; } = 0;
        public Team team { get; set; }
        public int TeamId { get; set; }

        public Player() { }
        public Player(string name, string surname, int teamId)
        {
            Name = name;
            Surname = surname;
            TeamId = teamId;
        }

        public enum Position
        {
            Goalie,
            Defender,
            Midfield,
            Attack,
            Coach,
            Staff
        }
    }
}
