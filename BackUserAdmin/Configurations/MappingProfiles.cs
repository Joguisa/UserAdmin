using AutoMapper;
using BackUserAdmin.DTOs;
using BackUserAdmin.Models;

namespace BackUserAdmin.Configurations
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserDto>();
            CreateMap<UserDto, User>();
        }
    }

}
