using Azure.Storage.Blobs;
using AzureTesting.Database;
using AzureTesting.DTO.Image;
using AzureTesting.Model;

namespace AzureTesting.Service.BlobServ
{
    public class BlobService : IBlobService
    {
        private readonly BlobContainerClient _blob;
        private readonly DatabaseContext databaseContext;

        public BlobService(IConfiguration configuration, DatabaseContext _databaseContext)
        {
            databaseContext = _databaseContext;
            var connectionString = configuration["AzureBlobStorage:ConnectionString"];
            var containerName = configuration["AzureBlobStorage:ContainerName"];
            _blob = new BlobContainerClient(connectionString, containerName);
        }

        public async Task<string> AddBlob(IFormFile file)
        {
            var blobClient = _blob.GetBlobClient(Guid.NewGuid().ToString() + Path.GetExtension(file.FileName));

            using (var stream = file.OpenReadStream())
            {
                await blobClient.UploadAsync(stream, overwrite: true);
            }

            return blobClient.Uri.AbsoluteUri;
        }

        public Image? GetSingleImageByUrl(string url) => databaseContext.Images.Where(i => i.BlobUrl == url).FirstOrDefault();

        public IEnumerable<ImageDTO> GetImages() => databaseContext.Images.Select(
            i => new ImageDTO()
            {
                Id = i.Id,
                Name = i.Name,
                BlobUrl = i.BlobUrl
            });

        public void SaveImageAsync(string blobUrl, string FileName)
        {
            Image newImage = new Image(blobUrl, FileName);
            databaseContext.Images.Add(newImage);
            databaseContext.SaveChanges();
        }

    }
}
