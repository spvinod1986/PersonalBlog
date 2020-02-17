using System.Collections.Generic;
using System.Threading.Tasks;
using PersonalBlog.Domain.Models;

namespace PersonalBlog.Business.Blogs
{
    public interface IBlogLogic
    {
        Task<List<Blog>> GetAllAsync();
        Task<List<Blog>> GetAsync();
        Task<Blog> GetAsync(string blogId);
        Task<Blog> GetByTitleUrlAsync(string titleUrl);
        Task<Blog> CreateAsync(Blog blog);
        Task<bool> UpdateAsync(string blogId, Blog blog);
        Task<bool> DeleteAsync(string blogId);
    }
}