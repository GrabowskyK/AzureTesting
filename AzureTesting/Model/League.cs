namespace AzureTesting.Model
{
    public class League
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string ShortName { get; set; }
        public int year { get; set; } = DateTime.Now.Year;
        public Image? Image { get; set; }
        public int? ImageId { get; set; }
    }
}
