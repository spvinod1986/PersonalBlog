using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PersonalBlog.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageController : ControllerBase
    {
        private readonly IWebHostEnvironment _environment;
        public ImageController(IWebHostEnvironment environment)
        {
            _environment = environment ?? throw new ArgumentNullException(nameof(environment));
        }

        [HttpPost]
        public async Task<JsonResult> Post(IFormFile file)
        {
            var uploads = Path.Combine(_environment.WebRootPath, "uploads");
            Directory.CreateDirectory(uploads);

            if (file.Length > 0)
            {
                using (var fileStream = new FileStream(Path.Combine(uploads, file.FileName), FileMode.Create))
                {
                    await file.CopyToAsync(fileStream);
                }
            }
            return new JsonResult(new ImageResult
            {
                Url = $"https://localhost:5001/uploads/{file.FileName}"
            });
        }
    }

    public class ImageResult
    {
        public string Url { get; set; }
    }
}