namespace AzureTesting.Model
{
    public class Image
    {
        public int Id { get; set; }
        public byte[] FileBlob { get; set; }
        public string Name { get; set; }
        public string CreatedDate { get; set; } = DateTime.UtcNow.ToString();

        public Image(byte[] fileBlob, string name)
        {
            FileBlob = fileBlob;
            Name = name;
        }
    }
}
