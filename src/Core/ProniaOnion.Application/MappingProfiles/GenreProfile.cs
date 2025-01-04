using AutoMapper;
using ProniaOnion.Application.DTOs.GenreDto;
using ProniaOnion.Domain.Entities;


namespace ProniaOnion.Application.MappingProfiles
{
    internal class GenreProfile:Profile
    {
        public GenreProfile()
        {
            CreateMap<Genre,GenreItemDto>();
            CreateMap<Genre, GetGenreDto>();
            CreateMap<CreateGenreDto, Genre>();
            CreateMap<UpdateGenreDto,Genre>().ForMember(a => a.Id, opt => opt.Ignore());
        }
    }
}
