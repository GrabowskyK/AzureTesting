namespace AzureTesting.DTO.Team
{
    public class AddTeamDTO
    {
        public string Name { get; set; }
        public string ShortName { get; set; }
        public IFormFile? image { get; set; }

        public AddTeamDTO() { }
        public AddTeamDTO(string name, string shortName)
        {
            Name = name;
            ShortName = shortName;
        }
    }
}
