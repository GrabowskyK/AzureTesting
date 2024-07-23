namespace AzureTesting.Service.BlobServ
{
    public interface IBlobService
    {
        Task<string> AddBlobAsync(IFormFile file);
    }
}