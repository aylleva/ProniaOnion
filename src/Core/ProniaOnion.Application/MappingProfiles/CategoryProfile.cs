using AutoMapper;
using ProniaOnion.Application.DTOs;
using ProniaOnion.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProniaOnion.Application.MappingProfiles
{
    internal class CategoryProfile:Profile
    {
        public CategoryProfile()
        {
            CreateMap<Category,CategoryItemDto>().ReverseMap();
            CreateMap<Category, GetCategoryDto>();
            CreateMap<CreateCategoryDto,Category>();
            CreateMap<UpdateCategoryDto, Category>();
        }
    }
}
