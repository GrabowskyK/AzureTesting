using Microsoft.Identity.Client;

namespace AzureTesting.DTO.Team
{
    public class TeamDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }
        public string? BlobURL { get; set; }
        public int LeagueId { get; set; }

        public TeamDTO() { }
        public TeamDTO(string name, string shortName)
        {
            Name = name;
            ShortName = shortName;
        }
    }
}
