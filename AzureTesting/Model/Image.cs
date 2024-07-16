namespace AzureTesting.Model
{
    public class Image
    {
        public int Id { get; set; }
        public byte[] fileBlob { get; set; }
        public string Name { get; set; }
        public string CreatedDate { get; set; } = DateTime.UtcNow.ToString();
    }
}
