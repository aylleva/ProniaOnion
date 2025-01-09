using AutoMapper;
using ProniaOnion.Application.DTOs.AppUsersDto;
using ProniaOnion.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProniaOnion.Application.MappingProfiles
{
    public class AppUserProfile:Profile
    {
        public AppUserProfile()
        {
            CreateMap<RegisterDto, AppUser>();
            
        }
    }
}
