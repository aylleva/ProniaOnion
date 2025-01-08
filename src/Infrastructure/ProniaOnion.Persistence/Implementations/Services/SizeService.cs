using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProniaOnion.Application.Abstractions.Repositories;
using ProniaOnion.Application.Abstractions.Services;
using ProniaOnion.Application.DTOs;
using ProniaOnion.Domain.Entities;


namespace ProniaOnion.Persistence.Implementations.Services
{
   public class SizeService:ISizeService
    {
        private readonly ISizeRepository _repository;
        private readonly IMapper _mapper;

        public SizeService(ISizeRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<SizeItemDto>> GetAllAsync(int page, int take)
        {
            IEnumerable<Size> sizes = await _repository.GetAll(skip: (page - 1) * take, take: take)
                 .ToListAsync();

            return _mapper.Map<IEnumerable<SizeItemDto>>(sizes);
        }

        public async Task<GetSizeDto> GetByIdAsync(int id)
        {
          var size = await _repository.GetbyIdAsync(id);
            if (size == null) throw new Exception("Not Found");


            return _mapper.Map<GetSizeDto>(size);
        }

        public async Task CreateAsync(CreateSizeDto sizedto)
        {
         

            var size = _mapper.Map<Size>(sizedto);

            
            await _repository.AddAsync(size);
            await _repository.SaveChangesAsync();
        }

        public async Task UpdateAsync(int Id, UpdateSizeDto sizedto)
        {
            var size = await _repository.GetbyIdAsync(Id);
            if (size == null) throw new Exception("Not Found");

            if (await _repository.AnyAsync(c => c.Name == sizedto.Name && c.Id != Id)) throw new Exception("This Size is already Exist");

            _mapper.Map(sizedto, size);
          
            _repository.Update(size);
            await _repository.SaveChangesAsync();
        }

        public async Task DeleteAsync(int Id)
        {
            var size = await _repository.GetbyIdAsync(Id);
            if (size == null) throw new Exception("Not Found");

            _repository.Delete(size);

            await _repository.SaveChangesAsync();
        }
    }
}
