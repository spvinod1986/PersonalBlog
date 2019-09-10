using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using PersonalBlog.Persistence;

namespace PersonalBlog.Business.Tests
{
    public class BlogContextFactory
    {
        public static BlogContext Create()
        {
            // Drop test database
            DeleteDatabase(TestSetting.ConnectionString, TestSetting.Database);

            var options = Options.Create(new BlogContextOptions
            {
                ConnectionString = TestSetting.ConnectionString,
                Database = TestSetting.Database
            });

            return new BlogContext(options);
        }

        public static void Destroy(BlogContext context)
        {
            DeleteDatabase(TestSetting.ConnectionString, TestSetting.Database);
            context = null;
        }

        private static void DeleteDatabase(string connectionString, string databaseName)
        {
            var client = new MongoClient(connectionString);
            client.DropDatabase(databaseName);
        }
    }
}