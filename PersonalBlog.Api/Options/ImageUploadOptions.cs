namespace PersonalBlog.Api.Options
{
    public class ImageUploadOptions
    {
        public string LocalServerUrl { get; set; }
        public string AzureBlobConnectionString { get; set; }
        public string AzureBlobImageContainer { get; set; }
        public string AzureBlobImageUrl { get; set; }
    }
}