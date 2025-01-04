using ProniaOnion.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProniaOnion.Application.Abstractions.Services
{
    public interface ITagService
    {
        Task<IEnumerable<TagItemDto>> GetAllAsync(int page, int take);

        Task<GetTagDto> GetByIdAsync(int id);

        Task CreateAsync(CreateTagDto tagdto);
        Task UpdateAsync(int Id, UpdateTagDto tagdto);

        Task DeleteAsync(int Id);
    }
}
