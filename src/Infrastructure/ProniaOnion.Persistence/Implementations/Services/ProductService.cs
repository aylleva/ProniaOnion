using AutoMapper;
using Microsoft.AspNetCore.Http.Metadata;
using Microsoft.EntityFrameworkCore;
using ProniaOnion.Application.Abstractions.Repositories;
using ProniaOnion.Application.Abstractions.Services;
using ProniaOnion.Application.DTOs;
using ProniaOnion.Application.DTOs.ProductDto;

namespace ProniaOnion.Persistence.Implementations.Services
{
    internal class ProductService : IProductService
    {
        private readonly IProductRepository _productrepo;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository productrepo,IMapper mapper)
        {
            _productrepo = productrepo;
            _mapper = mapper;
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

        public Task CreateAsync(CreateProductDto productdto)
        {
            throw new NotImplementedException();
        }
    }
}
