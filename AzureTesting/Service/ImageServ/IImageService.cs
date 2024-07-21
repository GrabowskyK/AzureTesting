using AzureTesting.DTO.Image;

namespace AzureTesting.Service.ImageServ
{
    public interface IImageService
    {
        void SaveImageAsync(IFormFile image);
        ImageDTO? GetImage(int imageId);
        IEnumerable<ImageDTO> GetImages();
    }
}