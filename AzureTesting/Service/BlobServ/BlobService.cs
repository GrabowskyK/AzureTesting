using Azure.Storage.Blobs;

namespace AzureTesting.Service.BlobServ
{
    public class BlobService : IBlobService
    {
        private readonly BlobContainerClient _blob;
        
        public BlobService(IConfiguration configuration) 
        {
            var connectionString = configuration["AzureBlobStorage:ConnectionString"];
            var containerName = configuration["AzureBlobStorage:ContainerName"];
            _blob = new BlobContainerClient(connectionString, containerName);
        }

        public async Task<string> AddBlobAsync(IFormFile file)
        {
            var blobClient = _blob.GetBlobClient(Guid.NewGuid().ToString() + Path.GetExtension(file.FileName));

            using (var stream = file.OpenReadStream())
            {
                await blobClient.UploadAsync(stream, overwrite: true);
            }

            return blobClient.Uri.ToString();
        }
    }
}
