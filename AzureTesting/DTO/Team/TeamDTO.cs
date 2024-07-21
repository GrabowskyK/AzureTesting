using Microsoft.Identity.Client;

namespace AzureTesting.DTO.Team
{
    public class TeamDTO
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string ShortName { get; set; }
        public int? ImageId { get; set; }  

    }
}
