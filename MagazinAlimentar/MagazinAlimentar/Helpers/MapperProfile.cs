﻿using AutoMapper;
using MagazinAlimentar.DTOs;
using MagazinAlimentar.Models;

namespace MagazinAlimentar.Helpers
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<User, UserDTO>();
            CreateMap<UserDTO, User>();
        }
    }
}
