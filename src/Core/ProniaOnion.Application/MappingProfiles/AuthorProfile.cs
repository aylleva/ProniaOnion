using AutoMapper;
using ProniaOnion.Application.DTOs.AuthorDto;
using ProniaOnion.Domain.Entities;



namespace ProniaOnion.Application.MappingProfiles
{
    internal class AuthorProfile:Profile
    {
        public AuthorProfile()
        {
            CreateMap<Author,AuthorItemDto>();
            CreateMap<Author,GetAuthorDto>();
            CreateMap<CreateAuthorDto, Author>();
            CreateMap<UpdateAuthorDto, Author>().ForMember(a=>a.Id,opt=>opt.Ignore());
        }
    }
}
