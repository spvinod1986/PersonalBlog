using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using PersonalBlog.Api.Options;

namespace PersonalBlog.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageController : ControllerBase
    {
        private readonly IWebHostEnvironment _environment;
        private readonly ImageUploadOptions _options;
        public ImageController(IWebHostEnvironment environment, IOptions<ImageUploadOptions> options)
        {
            _environment = environment ?? throw new ArgumentNullException(nameof(environment));
            _options = options.Value;
        }

        [HttpPost]
        [Authorize]
        public async Task<JsonResult> Post(IFormFile upload)
        {
            if (upload == null)
                throw new ArgumentException("Image to upload should not be null or empty");

            var uploads = Path.Combine(_environment.WebRootPath, "uploads");
            Directory.CreateDirectory(uploads);

            if (upload.Length > 0)
            {
                using (var fileStream = new FileStream(Path.Combine(uploads, upload.FileName), FileMode.Create))
                {
                    await upload.CopyToAsync(fileStream);
                }
            }
            return new JsonResult(new ImageResult
            {
                Url = $"{_options.Url}{upload.FileName}"
            });
        }
    }

    public class ImageResult
    {
        public string Url { get; set; }
    }
}