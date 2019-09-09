using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using PersonalBlog.Domain.Models;

namespace PersonalBlog.Persistence
{
    public class BlogContext
    {
        private readonly IMongoDatabase _database = null;

        public BlogContext(IOptions<BlogContextSettings> settings)
        {
            var client = new MongoClient(settings.Value.ConnectionString);
            if (client != null)
                _database = client.GetDatabase(settings.Value.Database);
        }

        public IMongoCollection<Blog> Blogs
        {
            get
            {
                return _database.GetCollection<Blog>("Blogs");
            }
        }

        public async Task DeleteDatabase(string databaseName)
        {
            await _database.Client.DropDatabaseAsync(databaseName);
        }

        public async Task DeleteCollection(string collectionName)
        {
            await _database.DropCollectionAsync(collectionName);
        }
    }
}