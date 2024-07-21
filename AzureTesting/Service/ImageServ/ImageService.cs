using AzureTesting.Database;
using AzureTesting.DTO.Image;
using AzureTesting.Model;

namespace AzureTesting.Service.ImageServ
{
    public class ImageService : IImageService
    {
        private readonly DatabaseContext databaseContext;
        public ImageService(DatabaseContext _databaseContext)
        {
            databaseContext = _databaseContext;
        }

        public void SaveImageAsync(IFormFile image)
        {
            Image newImage;
            using (var memoryStream = new MemoryStream())
            {
                var fileBytes = memoryStream.ToArray();
                newImage = new Image(fileBytes, image.FileName);      
            }
            databaseContext.Images.Add(newImage);
            databaseContext.SaveChanges();
        }

        public ImageDTO? GetImage(int imageId) => databaseContext.Images
            .Select(i => new ImageDTO()
            {
                Name = i.Name,
                Bytes = i.FileBlob
            }).FirstOrDefault();

        public IEnumerable<ImageDTO> GetImages() => databaseContext.Images
            .Select(i => new ImageDTO()
            {
                Name = i.Name,
                Bytes = i.FileBlob
            });
    }
}
