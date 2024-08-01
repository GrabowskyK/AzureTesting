namespace AzureTesting.DTO.League
{
    public class CreateLeague
    {
        public string Name { get; set; }
        public string ShortName { get; set; }
        public IFormFile? File { get; set; }

        public CreateLeague(string name, string shortName)
        {
            Name = name;
            ShortName = shortName;
        }
    }
}
