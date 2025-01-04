using ProniaOnion.Application.DTOs;
using ProniaOnion.Application.DTOs.AuthorDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProniaOnion.Application.Abstractions.Services
{
    public interface IAuthorService
    {
        Task<IEnumerable<AuthorItemDto>> GetAllAsync(int page, int take);

        Task<GetAuthorDto> GetbyIdAsync(int id);

        Task CreateAsync(CreateAuthorDto authordto);

        Task UpdateAsync(int id,UpdateAuthorDto author);

        Task DeleteAsync(int id);
    }
}
