using AutoMapper;
using DAW_Lab4.Models;
using DAW_Lab4.Models.DTOs;

namespace DAW_Lab4.Helpers
{
    public class MapperProfile: Profile
    {
        public MapperProfile() {

            CreateMap<User, UserDto>();
            CreateMap<UserDto, User>();

            CreateMap<User, UserDto>()
                .ForMember(ud => ud.FullName,
                opts => opts.MapFrom(u => u.FirstName + u.LastName));
        }
    }
}
