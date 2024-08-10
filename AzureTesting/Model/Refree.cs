namespace AzureTesting.Model
{
    public class Refree
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }

        public ICollection<Game> Games { get; set; }
        
        public Refree() { }
    }
}
