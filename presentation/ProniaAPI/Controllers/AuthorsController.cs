using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProniaOnion.Application.Abstractions.Services;

using ProniaOnion.Application.DTOs.AuthorDto;

namespace ProniaAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly IAuthorService _service;

        public AuthorsController(IAuthorService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Get(int page = 1, int take = 2)
        {

            return Ok(await _service.GetAllAsync(page, take));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            if (id < 1) return BadRequest();
            var authordto = await _service.GetbyIdAsync(id);
            if (authordto == null) return NotFound();

            return Ok(authordto);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromForm] CreateAuthorDto authordto)
        {

            await _service.CreateAsync(authordto);
            return Created();
        }
        [HttpPut("{id}")]

        public async Task<IActionResult> Put(int id, [FromForm] UpdateAuthorDto authordto)
        {
            if (id < 1) return BadRequest();
            await _service.UpdateAsync(id, authordto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id < 1) return BadRequest();
            await _service.DeleteAsync(id);
            return NoContent();
        }
    }
}
