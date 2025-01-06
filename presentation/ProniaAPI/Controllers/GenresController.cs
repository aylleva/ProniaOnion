using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProniaOnion.Application.Abstractions.Services;
using ProniaOnion.Application.DTOs;
using ProniaOnion.Application.DTOs.GenreDto;

namespace ProniaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenresController : ControllerBase
    {
        private readonly IGenreService _service;
        private readonly IValidator<CreateGenreDto> _validator;

        public GenresController(IGenreService service,IValidator<CreateGenreDto> validator)
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
            var genredto = await _service.GetbyIdAsync(Id);
            if (genredto == null) return NotFound();
            return Ok(genredto);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] CreateGenreDto genredto)
        {
            var result = await _validator.ValidateAsync(genredto);

            if (!result.IsValid)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                }
                return BadRequest(ModelState);
            }
            await _service.CreateAsync(genredto);
            return NoContent();
        }

        [HttpPut("{Id}")]
        public async Task<IActionResult> Update(int Id, [FromForm] UpdateGenreDto genredto)
        {
            if (Id < 1) return BadRequest();
            await _service.UpdateAsync(Id, genredto);
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
