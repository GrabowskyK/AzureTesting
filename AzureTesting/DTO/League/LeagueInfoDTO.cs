using AzureTesting.DTO.Image;

namespace AzureTesting.DTO.League
{
    public class LeagueInfoDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }
        public ImageDTO? Image { get; set; }

        public LeagueInfoDTO(string name, string shortName)
        {
            Name = name;
            ShortName = shortName;
        }

    }
}
