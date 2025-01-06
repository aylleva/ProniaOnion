using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProniaOnion.Application.Abstractions.Services;
using ProniaOnion.Application.DTOs;

namespace ProniaAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ColorsController : ControllerBase
    {
        private readonly IColorService _service;
        private readonly IValidator<CreateColorDto> _validator;

        public ColorsController(IColorService service,IValidator<CreateColorDto> validator)
        {
            _service = service;
            _validator = validator;
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
            var colordto = await _service.GetByIdAsync(Id);
            if (colordto == null) return NotFound();
            return Ok(colordto);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] CreateColorDto colordto)
        {
            var result = await _validator.ValidateAsync(colordto);

            if (!result.IsValid)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                }
                return BadRequest(ModelState);
            }
            await _service.CreateAsync(colordto);
            return NoContent();
        }

        [HttpPut("{Id}")]
        public async Task<IActionResult> Update(int Id, [FromForm] UpdateColorDto colordto)
        {
            if (Id < 1) return BadRequest();
            await _service.UpdateAsync(Id, colordto);
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
