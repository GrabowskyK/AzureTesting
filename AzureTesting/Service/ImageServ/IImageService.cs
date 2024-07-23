using AzureTesting.DTO.Image;

namespace AzureTesting.Service.ImageServ
{
    public interface IImageService
    {
        void SaveImageAsync(string blobUrl, string FileName);
    }
}