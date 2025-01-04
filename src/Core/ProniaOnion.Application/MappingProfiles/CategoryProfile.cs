using AutoMapper;
using ProniaOnion.Application.DTOs;
using ProniaOnion.Domain.Entities;


namespace ProniaOnion.Application.MappingProfiles
{
    internal class CategoryProfile:Profile
    {
        public CategoryProfile()
        {
            CreateMap<Category,CategoryItemDto>().ReverseMap();
            CreateMap<Category, GetCategoryDto>();
            CreateMap<CreateCategoryDto,Category>();
            CreateMap<UpdateCategoryDto, Category>().ForMember(c=>c.Id,opt=>opt.Ignore());
        }
    }
}
