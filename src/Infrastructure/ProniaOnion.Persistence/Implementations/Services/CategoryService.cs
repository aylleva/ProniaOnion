using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProniaOnion.Application.Abstractions.Repositories;
using ProniaOnion.Application.Abstractions.Services;
using ProniaOnion.Application.DTOs;
using ProniaOnion.Domain.Entities;

namespace ProniaOnion.Persistence.Implementations.Services
{
     public class CategoryService : ICategoryService
     {
        private readonly ICategoryRepository _repository;
        private readonly IMapper _mapper;

        public CategoryService(ICategoryRepository repository,IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }



        public async Task<IEnumerable<CategoryItemDto>> GetAllAsync(int page, int take)
        {
            IEnumerable<Category> categories = await _repository.GetAll(skip: (page - 1) * take, take: take)
                 .ToListAsync();
                
            return _mapper.Map<IEnumerable<CategoryItemDto>>(categories);
        }

        public async Task<GetCategoryDto> GetbyIdAsync(int id)
        {
            Category category = await _repository.GetbyIdAsync(id,nameof(Category.Products));

            if (category is null) throw new Exception("Category does not exist");

            return _mapper.Map<GetCategoryDto>(category);
        }

        public async Task CreateAsync(CreateCategoryDto categoryDto)
        {
            var category= _mapper.Map<Category>(categoryDto);

            category.CreatedAt=DateTime.Now;
           category.UpdatedAt=DateTime.Now;
            category.CreatedBy = "admin";
            await _repository.AddAsync(category);
            await _repository.SaveChangesAsync();
        }

        public async Task UpdateAsync(int id, UpdateCategoryDto categoryDto)
        {
            Category category = await _repository.GetbyIdAsync(id);
            if (category is null) throw new Exception("Not Found");

            if (await _repository.AnyAsync(c => c.Name == categoryDto.Name && c.Id != id)) throw new Exception("Category is already exists");

            _mapper.Map(categoryDto,category);
            category.UpdatedAt=DateTime.Now;
            _repository.Update(category);
            await _repository.SaveChangesAsync();
        }


        public async Task DeleteAsync(int id)
        {
            Category category = await _repository.GetbyIdAsync(id);
            if (category is null) throw new Exception("Not Found");

            _repository.Delete(category);
            await _repository.SaveChangesAsync();
        }
    }
}
