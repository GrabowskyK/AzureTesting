using AzureTesting.DTO.Image;
using AzureTesting.Model;

namespace AzureTesting.Service.BlobServ
{
    public interface IBlobService
    {
        Task<string> AddBlob(IFormFile file);
        IEnumerable<ImageDTO> GetImages();
        Image? GetSingleImageByUrl(string url);

        void SaveImageAsync(string blobUrl, string FileName);
    }
}