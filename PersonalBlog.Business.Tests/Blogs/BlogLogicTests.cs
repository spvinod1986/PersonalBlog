using System.Collections.Generic;
using System.Linq;
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

            // Setup
            _context.Blogs.InsertMany(new List<Blog>
            {
                new Blog{ Title = "Title1", Content  = "Content1" },
                new Blog{ Title = "Title2", Content  = "Content2" },
                new Blog{ Title = "Title3", Content  = "Content3" }
            });
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

        [Fact]
        public async Task UpdateBlog_updates_blog()
        {
            IBlogLogic logic = new BlogLogic(_context);
            var existingBlogs = await logic.GetAsync();

            var existingBlog = existingBlogs.FirstOrDefault(b => b.Title == "Title1");
            existingBlog.Title = "UpdatedTitle1";

            var result = await logic.UpdateAsync(existingBlog.Id, existingBlog);
            result.Should().BeTrue();
            (await logic.GetAsync()).FirstOrDefault(b => b.Id == existingBlog.Id).Title.Should().Be("UpdatedTitle1");
        }

        [Fact]
        public async Task DeleteBlog_deletes_blog()
        {
            IBlogLogic logic = new BlogLogic(_context);
            var existingBlogs = await logic.GetAsync();

            var existingBlog = existingBlogs.FirstOrDefault(b => b.Title == "Title2");

            var result = await logic.DeleteAsync(existingBlog.Id);
            result.Should().BeTrue();
            (await logic.GetAsync()).Any(b => b.Id == existingBlog.Id).Should().BeFalse();
        }
    }
}