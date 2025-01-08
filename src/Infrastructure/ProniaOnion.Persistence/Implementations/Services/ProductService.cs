using AutoMapper;

using Microsoft.EntityFrameworkCore;
using ProniaOnion.Application.Abstractions.Repositories;
using ProniaOnion.Application.Abstractions.Services;
using ProniaOnion.Application.DTOs;
using ProniaOnion.Application.DTOs.ProductDto;
using ProniaOnion.Domain.Entities;
using Color = ProniaOnion.Domain.Entities.Color;

namespace ProniaOnion.Persistence.Implementations.Services
{
    internal class ProductService : IProductService
    {
        private readonly IProductRepository _productrepo;
        private readonly IMapper _mapper;
        private readonly ICategoryRepository _categoryRepo;
    

        public ProductService(IProductRepository productrepo,IMapper mapper,ICategoryRepository categoryRepo)
        {
            _productrepo = productrepo;
            _mapper = mapper;
            _categoryRepo = categoryRepo;
           
        }
        public async Task<IEnumerable<ProductItemDto>> GetAll(int page, int take)
        {
           var products=await _productrepo.GetAll(skip:(page-1)*take,take:take).ToListAsync();

            return  _mapper.Map<IEnumerable<ProductItemDto>>(products);   
        }

        public async Task<GetProductDto> GetByIdAsync(int id)
        {
            var product=await _productrepo.GetbyIdAsync(id,"Category","ProductColors.Color","ProductSizes.Size","ProductTags.Tag");
            if (product is null) throw new Exception("Not Found");

            return _mapper.Map<GetProductDto>(product);
        }

        public async Task CreateAsync(CreateProductDto productdto)
        {
            if (!await _categoryRepo.AnyAsync(c => c.Id == productdto.CategoryId)) throw new Exception("Category was not found");

            CheckManytoMany<Color>(productdto.ColorIds);
            CheckManytoMany<Tag>(productdto.TagIds);
            CheckManytoMany<Size>(productdto.SizeIds);


            await _productrepo.AddAsync(_mapper.Map<Product>(productdto));
            await _productrepo.SaveChangesAsync();
        }


        public async  Task UpdateAsync(int Id, UpdateProductDto productdto)
        {
            var product = await _productrepo.GetbyIdAsync(Id,"ProductColors","ProductSizes","ProductTags");

            if (product.CategoryId != productdto.CategoryId)
                if (!await _categoryRepo.AnyAsync(c => c.Id == productdto.CategoryId))
                    throw new Exception("Not Found");

            ICollection<int> coloritems =productdto.ColorIds.Where(cI=>!product.ProductColors.Any(pc=>pc.ColorId==cI)).ToList();
            await CheckManytoMany<Color>(coloritems);

            ICollection<int> tagitems = productdto.TagIds.Where(tI => !product.ProductTags.Any(pt => pt.TagId == tI)).ToList();
            await CheckManytoMany<Tag>(tagitems);

            ICollection<int> sizeitems=productdto.SizeIds.Where(sI=>product.ProductSizes.Any(ps=>ps.SizeId==sI)).ToList();  
            await CheckManytoMany<Size>(sizeitems);

             _productrepo.Update(_mapper.Map(productdto,product));
             await _productrepo.SaveChangesAsync();

        }

        public async Task DeleteAsync(int Id)
        {
            var product=await _productrepo.GetbyIdAsync(Id);
            if (product is null) throw new Exception("Not Found");

            _productrepo.Delete(product);
            await _productrepo.SaveChangesAsync();
        }




        private async Task<IEnumerable<T>> CheckManytoMany<T>(ICollection<int> Ids) where T:BaseEntity
        {
            var entities = await _productrepo.CheckIds<T>(Ids);
            if (entities.Count() != Ids.Distinct().Count()) throw new Exception("Wrong");
            return  entities;    

        }

        

       
    }
}
