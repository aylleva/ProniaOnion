using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProniaOnion.Application.Abstractions.Services;
using ProniaOnion.Application.DTOs.BlogDto;


namespace ProniaAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class BlogsController : ControllerBase
    {
        private readonly IBlogService _service;

        public BlogsController(IBlogService service)
        {
          _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Get(int page = 1, int take = 2)
        {
            return Ok(await _service.GetAllAsync(page, take));
        }

        [HttpGet("{Id}")]

        public async Task<IActionResult> Get(int Id)
        {
            if (Id < 1) return BadRequest();
            var blogdto = await _service.GetbyIdAsync(Id);
            if (blogdto == null) return NotFound();
            return Ok(blogdto);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] CreateBlogDto blogdto)
        {
            await _service.CreateAsync(blogdto);
            return NoContent();
        }

        [HttpPut("{Id}")]
        public async Task<IActionResult> Update(int Id, [FromForm] UpdateBlogDto blogdto)
        {
            if (Id < 1) return BadRequest();
            await _service.UpdateAsync(Id,blogdto);
            return NoContent();
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete(int Id)
        {
            if (Id < 1) return BadRequest();
            await _service.DeleteAsync(Id);
            return NoContent();
        }
    }
}
