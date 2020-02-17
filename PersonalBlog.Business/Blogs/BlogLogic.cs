using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Driver;
using PersonalBlog.Domain.Models;
using PersonalBlog.Persistence;
using MongoDB.Driver.Linq;
using System.Text.RegularExpressions;
using System;

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
            var titleUrl = Regex.Replace(blog.Title.Trim(), @"[^0-9a-zA-Z]+", "-");
            blog.TitleUrl = titleUrl.Replace(" ", "-").ToLower();
            blog.CreatedAt = DateTime.Now;
            blog.UpdatedAt = DateTime.Now;
            blog.UpdatedBy = blog.CreatedBy;
            blog.IsPublished = false;

            await _context.Blogs.InsertOneAsync(blog);
            return blog;
        }

        public async Task<bool> DeleteAsync(string blogId)
        {
            var filter = Builders<Blog>.Filter.Where(b => b.Id == blogId);

            await _context.Blogs.DeleteOneAsync(filter);
            return true;
        }

        public async Task<List<Blog>> GetAllAsync()
        {
            return await _context.Blogs.AsQueryable<Blog>()
                                .OrderByDescending(b => b.UpdatedAt).ToListAsync();
        }

        public async Task<List<Blog>> GetAsync()
        {
            return await _context.Blogs.AsQueryable<Blog>()
                                .Where(b => b.IsPublished == true)
                                .OrderByDescending(b => b.UpdatedAt).ToListAsync();
        }

        public async Task<Blog> GetAsync(string blogId)
        {
            return await _context.Blogs.AsQueryable<Blog>().Where(b => b.Id == blogId).FirstOrDefaultAsync();
        }

        public async Task<Blog> GetByTitleUrlAsync(string titleUrl)
        {
            return await _context.Blogs.AsQueryable<Blog>().Where(b => b.TitleUrl == titleUrl).FirstOrDefaultAsync();
        }

        public async Task<bool> UpdateAsync(string blogId, Blog blog)
        {
            var titleUrl = Regex.Replace(blog.Title.Trim(), @"[^0-9a-zA-Z]+", "-");
            blog.TitleUrl = titleUrl.Replace(" ", "-").ToLower();
            blog.UpdatedAt = DateTime.Now;

            var filter = Builders<Blog>.Filter.Where(b => b.Id == blogId);
            var update = Builders<Blog>.Update.Set(b => b.Title, blog.Title)
                                            .Set(b => b.TitleUrl, blog.TitleUrl)
                                            .Set(b => b.Content, blog.Content)
                                            .Set(b => b.Tags, blog.Tags)
                                            .Set(b => b.IsPublished, blog.IsPublished)
                                            .Set(b => b.UpdatedAt, blog.UpdatedAt)
                                            .Set(b => b.UpdatedBy, blog.UpdatedBy);

            await _context.Blogs.UpdateOneAsync(filter, update);
            return true;
        }

    }
}