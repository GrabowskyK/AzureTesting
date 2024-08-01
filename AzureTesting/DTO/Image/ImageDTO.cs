using System.Reflection.Metadata;

namespace AzureTesting.DTO.Image
{
    public class ImageDTO
    {
        public int Id { get; set; }
        public string BlobUrl { get; set; }
        public string Name { get; set; }

        public ImageDTO() { }
        public ImageDTO(string blobUrl, string name)
        {
            BlobUrl = blobUrl;
            Name = name;
           
        }
    }
}
