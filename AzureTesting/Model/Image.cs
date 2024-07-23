namespace AzureTesting.Model
{
    public class Image
    {
        public int Id { get; set; }
        public string BlobUrl { get; set; }
        public string Name { get; set; }
        public string CreatedDate { get; set; } = DateTime.UtcNow.ToString();

        public Image(string blobUrl, string name)
        {
            BlobUrl = blobUrl;
            Name = name;
        }
    }
}
