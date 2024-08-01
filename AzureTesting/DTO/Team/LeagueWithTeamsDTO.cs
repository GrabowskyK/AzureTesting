namespace AzureTesting.DTO.Team
{
    public class LeagueWithTeamsDTO
    {
        public int id { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }
        public int Year { get; set; }
        public string? BlobUrl { get; set; }
        public List<TeamDTO> Teams { get; set; }

        public LeagueWithTeamsDTO() { }
        public LeagueWithTeamsDTO(string name, string shortName, int year)
        {
            Name = name;
            ShortName = shortName;
            Year = year;
        }
    }
}
