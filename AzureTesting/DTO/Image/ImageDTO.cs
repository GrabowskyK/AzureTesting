using System.Reflection.Metadata;

namespace AzureTesting.DTO.Image
{
    public class ImageDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public byte[] Bytes { get; set; }
        //public ImageDTO(string name, byte[] bytes) 
        //{
        //    Name = name;
        //    Bytes = bytes;
        //}
    }
}
