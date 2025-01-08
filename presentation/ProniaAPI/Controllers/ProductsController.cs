
using Microsoft.AspNetCore.Mvc;
using ProniaOnion.Application.Abstractions.Services;
using ProniaOnion.Application.DTOs.ProductDto;


namespace ProniaAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _service;

        public ProductsController(IProductService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Get(int page=1,int take = 3)
        {
            return Ok(await _service.GetAll(page, take));
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> Get(int Id)
        {
            if (Id < 1) return BadRequest();

            var productdto = await _service.GetByIdAsync(Id);
            if(productdto == null) return NotFound();

            return Ok(productdto);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromForm]CreateProductDto productdto)
        {
            await _service.CreateAsync(productdto);
            return Created();
        }
        [HttpPut]

        public async Task<IActionResult> Put(int Id,UpdateProductDto productDto)
        {
            if(Id < 1) return BadRequest();
            await _service.UpdateAsync(Id, productDto);
            return NoContent();
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int Id)
        {
            if(Id<1) return BadRequest();
            await _service.DeleteAsync(Id);
            return NoContent();
        }
    }
}
