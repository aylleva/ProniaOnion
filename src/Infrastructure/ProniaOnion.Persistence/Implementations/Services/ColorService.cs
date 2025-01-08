
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProniaOnion.Application.Abstractions.Repositories;
using ProniaOnion.Application.Abstractions.Services;
using ProniaOnion.Application.DTOs;
using ProniaOnion.Domain.Entities;

namespace ProniaOnion.Persistence.Implementations.Services
{
   public class ColorService : IColorService
    {
        private readonly IColorRepository _repository;
        private readonly IMapper _mapper;

        public ColorService(IColorRepository repository,IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ColorItemDto>> GetAllAsync(int page, int take)
        {
            IEnumerable<Color> colors = await _repository.GetAll(skip: (page - 1) * take, take: take)
                 .ToListAsync();

            return _mapper.Map<IEnumerable<ColorItemDto>>(colors);
        }

        public async Task<GetColorDto> GetByIdAsync(int id)
        {
            Color color = await _repository.GetbyIdAsync(id);
            if (color == null) throw new Exception("Not Found");

           
            return _mapper.Map<GetColorDto>(color);
        }

        public async Task CreateAsync(CreateColorDto colordto)
        {
           
           
            var color=_mapper.Map<Color>(colordto);

         
            await _repository.AddAsync(color);
            await _repository.SaveChangesAsync();
        }

        public async Task UpdateAsync(int Id, UpdateColorDto colordto)
        {
            Color color = await _repository.GetbyIdAsync(Id);
            if (color == null) throw new Exception("Not Found");

            if (await _repository.AnyAsync(c => c.Name == colordto.Name && c.Id != Id)) throw new Exception("This Color is already Exist");

            _mapper.Map(colordto,color);
         
            _repository.Update(color);
            await _repository.SaveChangesAsync();
        }

        public async Task DeleteAsync(int Id)
        {
            Color color = await _repository.GetbyIdAsync(Id);
            if (color == null) throw new Exception("Not Found");

            _repository.Delete(color);

            await _repository.SaveChangesAsync();
        }
    }
}
