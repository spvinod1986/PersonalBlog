using System.Collections.Generic;
using System.Threading.Tasks;
using PersonalBlog.Domain.Models;

namespace PersonalBlog.Business.Blogs
{
    public interface IBlogLogic
    {
        Task<List<Blog>> GetAsync();
        Task<Blog> GetAsync(string blogId);
        Task<Blog> CreateAsync(Blog blog);
        Task<bool> UpdateAsync(Blog blog);
        Task<bool> DeleteAsync(Blog blog);
    }
}