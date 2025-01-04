using AutoMapper;
using ProniaOnion.Application.DTOs;
using ProniaOnion.Application.DTOs.BlogDto;
using ProniaOnion.Domain.Entities;


namespace ProniaOnion.Application.MappingProfiles
{
    internal class BlogProfile:Profile
    {
        public BlogProfile()
        {
            CreateMap<Blog,BlogItemDto>();
            CreateMap<Blog,GetBlogDto>();
            CreateMap<CreateBlogDto,Blog>();
            CreateMap<UpdateBlogDto, Blog>().ForMember(b => b.Id, opt => opt.Ignore());
        }
    }
}
