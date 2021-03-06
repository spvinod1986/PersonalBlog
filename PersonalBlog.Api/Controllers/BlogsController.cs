using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PersonalBlog.Business.Blogs;
using PersonalBlog.Domain.Models;

namespace PersonalBlog.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogsController : ControllerBase
    {
        private readonly IBlogLogic _blogLogic;
        public BlogsController(IBlogLogic blogLogic)
        {
            _blogLogic = blogLogic;
        }

        // GET api/blogs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Blog>>> Get()
        {
            return Ok(await _blogLogic.GetAsync());
        }

        // GET api/blogs/GetAll
        [HttpGet("GetAll")]
        public async Task<ActionResult<IEnumerable<Blog>>> GetAll()
        {
            return Ok(await _blogLogic.GetAllAsync());
        }

        // GET api/blogs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Blog>> Get(string id)
        {
            return Ok(await _blogLogic.GetAsync(id));
        }

        // GET api/blogs/GetByTitleUrl/asp-net-5
        [HttpGet("GetByTitleUrl/{titleUrl}")]
        public async Task<ActionResult<Blog>> GetByTitleUrl(string titleUrl)
        {
            return Ok(await _blogLogic.GetByTitleUrlAsync(titleUrl));
        }

        // POST api/blogs
        [HttpPost]
        [Authorize]
        public async Task<ActionResult<Blog>> Post([FromBody] Blog blog)
        {
            return Ok(await _blogLogic.CreateAsync(blog));
        }

        // PUT api/blogs/5
        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> Put(string id, [FromBody] Blog blog)
        {
            await _blogLogic.UpdateAsync(id, blog);
            return Ok();
        }

        // DELETE api/blogs/5
        [HttpDelete("{id}")]
        [Authorize]
        public async Task Delete(string id)
        {
            await _blogLogic.DeleteAsync(id);
        }
    }
}