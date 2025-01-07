using AutoMapper;
using ProniaOnion.Application.DTOs;
using ProniaOnion.Domain.Entities;

namespace ProniaOnion.Application.MappingProfiles
{
    public class SizeProfile:Profile
    {
        public SizeProfile()
        {
            CreateMap<Size,SizeItemDto>().ReverseMap();
            CreateMap<Size, GetSizeDto>();
            CreateMap<CreateSizeDto,Size>();
            CreateMap<UpdateSizeDto, Size>();

        }
    }
}
