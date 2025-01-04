using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProniaOnion.Application.Abstractions.Services;
using ProniaOnion.Application.DTOs;

namespace ProniaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SizesController : ControllerBase
    {
        private readonly ISizeService _service;

        public SizesController(ISizeService service)
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
            var sizedto = await _service.GetByIdAsync(Id);
            if (sizedto == null) return NotFound();
            return Ok(sizedto);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] CreateSizeDto sizedto)
        {
            await _service.CreateAsync(sizedto);
            return NoContent();
        }

        [HttpPut("{Id}")]
        public async Task<IActionResult> Update(int Id, [FromForm] UpdateSizeDto sizedto)
        {
            if (Id < 1) return BadRequest();
            await _service.UpdateAsync(Id, sizedto);
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

