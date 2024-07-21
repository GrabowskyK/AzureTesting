using System.ComponentModel.DataAnnotations;

namespace AzureTesting.Model
{
    public class Team
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [MaxLength(3)]
        public string ShortName { get; set; } 
        public Image? Image { get; set; }
        public int? ImageId { get; set; }
        public League? League { get; set; } //League can be null, because can be add to diffrent league.
        public int? LeagueId { get; set; }

        public Team(string name, string shortName, int? leagueId, int? imageId)
        {
            Name = name;
            ShortName = shortName;
            LeagueId = leagueId;
            ImageId = imageId;
        }

    }
}
