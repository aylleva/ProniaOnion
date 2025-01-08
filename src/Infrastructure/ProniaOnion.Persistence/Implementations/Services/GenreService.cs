using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProniaOnion.Application.Abstractions.Repositories;
using ProniaOnion.Application.Abstractions.Services;
using ProniaOnion.Application.DTOs;
using ProniaOnion.Application.DTOs.AuthorDto;
using ProniaOnion.Application.DTOs.GenreDto;
using ProniaOnion.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProniaOnion.Persistence.Implementations.Services
{
    public class GenreService:IGenreService
    {
        private readonly IGenreRepository _repository;
        private readonly IMapper _mapper;

        public GenreService(IGenreRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }



        public async Task<IEnumerable<GenreItemDto>> GetAllAsync(int page, int take)
        {
            IEnumerable<Genre> genres = await _repository.GetAll(skip: (page - 1) * take, take: take)
                 .ToListAsync();

            return _mapper.Map<IEnumerable<GenreItemDto>>(genres);
        }

        public async Task<GetGenreDto> GetbyIdAsync(int id)
        {
           var genre = await _repository.GetbyIdAsync(id, nameof(Genre.Blogs));

            if( genre is null) throw new Exception(" Genre does not exist");

            return _mapper.Map<GetGenreDto>(genre);
        }

        public async Task CreateAsync(CreateGenreDto genredto)
        {
           
            var genre = _mapper.Map<Genre>(genredto);

           
            await _repository.AddAsync(genre);
            await _repository.SaveChangesAsync();
        }

        public async Task UpdateAsync(int id, UpdateGenreDto genredto)
        {
           var genre = await _repository.GetbyIdAsync(id);
            if (genre is null) throw new Exception("Not Found");

            if (await _repository.AnyAsync(c => c.Name == genredto.Name && c.Id != id)) throw new Exception("Genre is already exists");

            _mapper.Map(genredto,genre);
         
            _repository.Update(genre);
            await _repository.SaveChangesAsync();
        }


        public async Task DeleteAsync(int id)
        {
           var genre = await _repository.GetbyIdAsync(id);
            if (genre is null) throw new Exception("Not Found");

            _repository.Delete(genre);
            await _repository.SaveChangesAsync();
        }
    }
}
