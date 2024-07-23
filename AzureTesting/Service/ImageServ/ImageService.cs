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

        public void SaveImageAsync(string blobUrl, string FileName)
        {
            Image newImage = new Image(blobUrl, FileName);
            databaseContext.Images.Add(newImage);
            databaseContext.SaveChanges();
        }


    }
}
