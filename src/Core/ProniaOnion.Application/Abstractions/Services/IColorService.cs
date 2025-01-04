

using ProniaOnion.Application.DTOs;

namespace ProniaOnion.Application.Abstractions.Services
{
    public interface IColorService
    {
        Task<IEnumerable<ColorItemDto>> GetAllAsync(int page, int take);

        Task<GetColorDto> GetByIdAsync(int id);

        Task CreateAsync(CreateColorDto colordto); 
        Task UpdateAsync(int Id, UpdateColorDto colordto);

        Task DeleteAsync(int Id);
    }
}
