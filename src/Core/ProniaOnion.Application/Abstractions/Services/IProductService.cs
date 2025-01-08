using ProniaOnion.Application.DTOs;
using ProniaOnion.Application.DTOs.ProductDto;


namespace ProniaOnion.Application.Abstractions.Services
{
    public interface IProductService
    {
        Task<IEnumerable<ProductItemDto>> GetAll(int page,int take);

        Task<GetProductDto> GetByIdAsync(int id);

        Task CreateAsync(CreateProductDto productdto);

        Task UpdateAsync(int Id,UpdateProductDto productdto);

        Task DeleteAsync(int Id);
    }
}
