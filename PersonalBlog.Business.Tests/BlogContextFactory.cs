using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using PersonalBlog.Persistence;

namespace PersonalBlog.Business.Tests
{
    public class BlogContextFactory
    {
        public static BlogContext Create()
        {
            var options = Options.Create(new BlogContextSettings
            {
                ConnectionString = TestSetting.ConnectionString,
                Database = TestSetting.Database
            });

            return new BlogContext(options);
        }

        public static async Task Destroy(BlogContext context)
        {
            await context.DeleteDatabase(TestSetting.Database);
            context = null;
        }
    }
}