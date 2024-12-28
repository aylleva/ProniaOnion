using ProniaOnion.Application.DTOs;



namespace ProniaOnion.Application.Abstractions.Services
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryItemDto>> GetAllAsync(int page, int take);

        Task<GetCategoryDto> GetbyIdAsync(int id);

        Task CreateAsync(CreateCategoryDto categoryDto);

        Task UpdateAsync(int id, UpdateCategoryDto categoryDto);

        Task DeleteAsync(int id);
    }
}
