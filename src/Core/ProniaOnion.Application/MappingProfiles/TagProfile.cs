using AutoMapper;
using ProniaOnion.Application.DTOs;
using ProniaOnion.Domain.Entities;


namespace ProniaOnion.Application.MappingProfiles
{
    public class TagProfile:Profile
    {
        public TagProfile()
        {
            CreateMap<Tag,TagItemDto>().ReverseMap();
            CreateMap<Tag, GetTagDto>();
            CreateMap<CreateTagDto, Tag>();
            CreateMap<UpdateTagDto, Tag>();
        }
    }
}
