using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Driver;
using PersonalBlog.Domain.Models;
using PersonalBlog.Persistence;
using MongoDB.Driver.Linq;

namespace PersonalBlog.Business.Blogs
{
    public class BlogLogic : IBlogLogic
    {
        private readonly BlogContext _context;
        public BlogLogic(BlogContext context)
        {
            _context = context;
        }

        public async Task<Blog> CreateAsync(Blog blog)
        {
            await _context.Blogs.InsertOneAsync(blog);
            return blog;
        }

        public async Task<bool> DeleteAsync(string blogId)
        {
            var filter = Builders<Blog>.Filter.Where(b => b.Id == blogId);

            await _context.Blogs.DeleteOneAsync(filter);
            return true;
        }

        public async Task<List<Blog>> GetAsync()
        {
            return await _context.Blogs.AsQueryable<Blog>().ToListAsync();
        }

        public async Task<Blog> GetAsync(string blogId)
        {
            return await _context.Blogs.AsQueryable<Blog>().Where(b => b.Id == blogId).FirstOrDefaultAsync();
        }

        public async Task<bool> UpdateAsync(string blogId, Blog blog)
        {
            var filter = Builders<Blog>.Filter.Where(b => b.Id == blogId);

            await _context.Blogs.ReplaceOneAsync(filter, blog);
            return true;
        }

    }
}