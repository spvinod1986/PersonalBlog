using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using PersonalBlog.Domain.Models;

namespace PersonalBlog.Persistence
{
    public class BlogContext
    {
        private readonly IMongoDatabase _database = null;

        public BlogContext(IOptions<BlogContextOptions> options)
        {
            var client = new MongoClient(options.Value.ConnectionString);
            if (client != null)
                _database = client.GetDatabase(options.Value.Database);
        }

        public IMongoCollection<Blog> Blogs
        {
            get
            {
                return _database.GetCollection<Blog>("Blogs");
            }
        }
    }
}