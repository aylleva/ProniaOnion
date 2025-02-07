﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using ProniaOnion.Application.Abstractions.Repositories;
using ProniaOnion.Application.Abstractions.Services;
using ProniaOnion.Application.DTOs;
using ProniaOnion.Application.DTOs.AuthorDto;
using ProniaOnion.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ProniaOnion.Persistence.Implementations.Services
{
    public class AuthorService:IAuthorService
    {
        private readonly IAuthorRepository _repository;
        private readonly IMapper _mapper;

        public AuthorService(IAuthorRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<AuthorItemDto>> GetAllAsync(int page, int take)
        {
            IEnumerable<Author> authors = await _repository.GetAll(skip: (page - 1) * take, take: take)
                 .ToListAsync();

            return _mapper.Map<IEnumerable<AuthorItemDto>>(authors);
        }

        public async Task<GetAuthorDto> GetbyIdAsync(int id)
        {
            var author = await _repository.GetbyIdAsync(id,nameof(Author.Blogs));
            if (author == null) throw new Exception("Not Found");


            return _mapper.Map<GetAuthorDto>(author);
        }

        public async Task CreateAsync(CreateAuthorDto authordto)
        {

            var author = _mapper.Map<Author>(authordto);

            author.CreatedAt = DateTime.Now;
            author.UpdatedAt = DateTime.Now;
            author.CreatedBy = "admin";
            await _repository.AddAsync(author);
            await _repository.SaveChangesAsync();
        }

        public async Task UpdateAsync(int Id,UpdateAuthorDto authordto)
        {
           var author = await _repository.GetbyIdAsync(Id);
            if (author== null) throw new Exception("Not Found");


            _mapper.Map(authordto, author);
            author.UpdatedAt = DateTime.Now;
            _repository.Update(author);
            await _repository.SaveChangesAsync();
        }

        public async Task DeleteAsync(int Id)
        {
           var author= await _repository.GetbyIdAsync(Id);
            if (author == null) throw new Exception("Not Found");

            _repository.Delete(author);

            await _repository.SaveChangesAsync();
        }

   
    }
}
