using AzureTesting.DTO.Image;
using AzureTesting.Model;
using AzureTesting.Service.ImageServ;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;

namespace AzureTesting.Controllers
{
    public class ImageController : ControllerBase
    {
        private readonly IImageService ImageService;
        private readonly ILogger<ImageController> logger;

        public ImageController(IImageService _imageService, ILogger<ImageController> _logger) 
        {
            ImageService = _imageService;
            logger = _logger;
        }

        [HttpPost("AddImage")]
        public ActionResult<IFormFile> AddImage(IFormFile file)
        {
            try
            {
                ImageService.SaveImageAsync(file);
                return Ok("Image has been save!");
            }
            catch (Exception ex) 
            {
                logger.LogError(ex.ToString());
                return BadRequest("Something went wrong with save file!");
            }
            
        }

        [HttpGet("GetImage")]
        public ActionResult<ImageDTO> GetImage(int id)
        {
            var result = ImageService.GetImage(id);
            return File(result.Bytes, "image/jpg");
        }

        [HttpGet("GetImages")]
        public ActionResult<ImageDTO> GetImages()
        {
            var result = ImageService.GetImages();
            return Ok(result);
        }

        [HttpPost("upload")]
        public async Task<IActionResult> UploadImage(IFormFile file)
        {
            if (file == null || file.Length == 0)
                return BadRequest("No file uploaded.");

            using (var memoryStream = new MemoryStream())
            {
                await file.CopyToAsync(memoryStream);
                var image = new Image(memoryStream.ToArray(), "pies");
                return File(image.FileBlob,"image/jpg"); // Zwraca ID nowo utworzonej encji
            }
        }
    }
}
