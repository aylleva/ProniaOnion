using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProniaOnion.Application.Abstractions.Repositories;
using ProniaOnion.Application.Abstractions.Services;
using ProniaOnion.Application.DTOs;
using ProniaOnion.Domain.Entities;


namespace ProniaOnion.Persistence.Implementations.Services
{
    public class TagService : ITagService
    {
        private readonly ITagRepository _repository;
        private readonly IMapper _mapper;

        public TagService(ITagRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<TagItemDto>> GetAllAsync(int page, int take)
        {
            IEnumerable<Tag> tags = await _repository.GetAll(skip: (page - 1) * take, take: take)
                 .ToListAsync();

            return _mapper.Map<IEnumerable<TagItemDto>>(tags);
        }

        public async Task<GetTagDto> GetByIdAsync(int id)
        {
            Tag tag= await _repository.GetbyIdAsync(id);
            if (tag == null) throw new Exception("Not Found");


            return _mapper.Map<GetTagDto>(tag);
        }

        public async Task CreateAsync(CreateTagDto tagdto)
        {
           

            var tag = _mapper.Map<Tag>(tagdto);

            
            await _repository.AddAsync(tag);
            await _repository.SaveChangesAsync();
        }

        public async Task UpdateAsync(int Id, UpdateTagDto tagdto)
        {
            var tag = await _repository.GetbyIdAsync(Id);
            if (tag== null) throw new Exception("Not Found");

            if (await _repository.AnyAsync(c => c.Name == tagdto.Name && c.Id != Id)) throw new Exception("This Tag is already Exist");

            _mapper.Map(tagdto,tag);
        
            _repository.Update(tag);
            await _repository.SaveChangesAsync();
        }

        public async Task DeleteAsync(int Id)
        {
           var tag = await _repository.GetbyIdAsync(Id);
            if (tag == null) throw new Exception("Not Found");

            _repository.Delete(tag);

            await _repository.SaveChangesAsync();
        }
    }
}
