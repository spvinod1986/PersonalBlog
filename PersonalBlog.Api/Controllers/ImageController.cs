using System;
using System.IO;
using System.Threading.Tasks;
using Azure.Storage.Blobs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using PersonalBlog.Api.Options;
using Microsoft.Extensions.Hosting;

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

            string uploadPath = null;
            try
            {
                // TODO: Replace this with Azurite
                if (_environment.IsDevelopment())
                    uploadPath = await UploadToServer(upload);
                else
                    uploadPath = await UploadToCloud(upload);
            }
            catch (System.Exception ex)
            {
                throw new Exception("Image Upload to Server Failed", ex);
            }

            return new JsonResult(new ImageResult
            {
                Url = uploadPath
            });
        }

        private async Task<string> UploadToServer(IFormFile file)
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
            return $"{_options.LocalServerUrl}{file.FileName}";
        }

        private async Task<string> UploadToCloud(IFormFile file)
        {
            BlobServiceClient blobServiceClient = new BlobServiceClient(_options.AzureBlobConnectionString);
            BlobContainerClient containerClient = blobServiceClient.GetBlobContainerClient(_options.AzureBlobImageContainer);
            BlobClient blobClient = containerClient.GetBlobClient(file.FileName);

            using var uploadFileStream = file.OpenReadStream();
            var test = await blobClient.UploadAsync(uploadFileStream, true);
            uploadFileStream.Close();

            return _options.AzureBlobImageUrl + file.FileName;
        }
    }

    public class ImageResult
    {
        public string Url { get; set; }
    }
}