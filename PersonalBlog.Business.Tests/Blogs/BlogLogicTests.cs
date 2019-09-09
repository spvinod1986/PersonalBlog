using System.Threading.Tasks;
using FluentAssertions;
using PersonalBlog.Business.Blogs;
using PersonalBlog.Domain.Models;
using PersonalBlog.Persistence;
using Xunit;

namespace PersonalBlog.Business.Tests.Blogs
{
    public class BlogLogicTests : IClassFixture<TestFixture>
    {
        private readonly BlogContext _context;
        public BlogLogicTests(TestFixture fixture)
        {
            _context = fixture.Context;
        }

        [Fact]
        public async Task CreateBlog_creates_blog()
        {
            IBlogLogic logic = new BlogLogic(_context);

            var blog = new Blog
            {
                Title = "CreateBlogTestTitle",
                Content = "CreateBlogTestContent"
            };

            var result = await logic.CreateAsync(blog);
            result.Id.Should().NotBeNullOrEmpty();
        }
    }
}