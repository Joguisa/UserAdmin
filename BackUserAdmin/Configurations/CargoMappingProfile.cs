using AutoMapper;
using BackUserAdmin.DTOs;
using BackUserAdmin.Models;

namespace BackUserAdmin.Configurations
{
    public class CargoMappingProfile : Profile
    {
        public CargoMappingProfile()
        {
            CreateMap<Cargo, CargoDto>();
            CreateMap<CargoDto, Cargo>();
        }
    }

}
