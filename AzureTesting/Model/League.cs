namespace AzureTesting.Model
{
    public class League
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }
        public int Year { get; set; } = DateTime.Now.Year;
        public Image? Image { get; set; }
        public int? ImageId { get; set; }
        public ICollection<Team> Teams { get; set; }


        public League(string name, string shortName)
        {
            Name = name;
            ShortName = shortName;
        }
    }
}
