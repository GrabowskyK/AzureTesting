using AzureTesting.DTO.Image;
using AzureTesting.Model;
using AzureTesting.Service.BlobServ;
using AzureTesting.Service.ImageServ;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;

namespace AzureTesting.Controllers
{
    public class ImageController : ControllerBase
    {
        private readonly IImageService ImageService;
        private readonly IBlobService blobService;
        private readonly ILogger<ImageController> logger;

        public ImageController(IImageService _imageService, IBlobService _blobService, ILogger<ImageController> _logger) 
        {
            ImageService = _imageService;
            blobService = _blobService;
            logger = _logger;
        }

        [HttpPost("AddImage")]
        public IActionResult AddImage(IFormFile file)
        {
            if (file.FileName != "jpg" && file.FileName != "png" && file.FileName != "jpeg")
            {
                return BadRequest("Wrong format!");
            }
            var urlFile = blobService.AddBlobAsync(file);
            ImageService.SaveImageAsync(urlFile.ToString(), file.FileName);
            return Ok();
        }
    }
}
