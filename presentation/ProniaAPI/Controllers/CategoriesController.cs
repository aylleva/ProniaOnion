using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProniaOnion.Application.Abstractions.Services;
using ProniaOnion.Application.DTOs;
using ProniaOnion.Application.FluentValidator;

namespace ProniaAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _service;
     

        public CategoriesController(ICategoryService service)
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
            var categorydto = await _service.GetbyIdAsync(id);
            if (categorydto == null) return NotFound();

            return Ok(categorydto);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromForm] CreateCategoryDto categorydto)
        {
          
            await _service.CreateAsync(categorydto);
            return Created();
        }
        [HttpPut("{id}")]

        public async Task<IActionResult> Put(int id, [FromForm] UpdateCategoryDto categorydto)
        {
            if (id < 1) return BadRequest();
            await _service.UpdateAsync(id, categorydto);
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
