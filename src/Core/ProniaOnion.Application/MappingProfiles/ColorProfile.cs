﻿using AutoMapper;
using ProniaOnion.Application.DTOs;
using ProniaOnion.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProniaOnion.Application.MappingProfiles
{
    internal class ColorProfile:Profile
    {
        public ColorProfile()
        {
            CreateMap<Color, ColorItemDto>().ReverseMap();
            CreateMap<Color, GetColorDto>();
            CreateMap<CreateColorDto, Color>();
            CreateMap<UpdateColorDto, Color>().ForMember(c=>c.Id,opt=>opt.Ignore());
        }
    }
}
