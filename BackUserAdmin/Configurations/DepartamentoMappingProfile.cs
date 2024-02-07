using AutoMapper;
using BackUserAdmin.DTOs;
using BackUserAdmin.Models;

namespace BackUserAdmin.Configurations
{
    public class DepartamentoMappingProfile : Profile
    {
        public DepartamentoMappingProfile()
        {
            CreateMap<Departamento, DepartamentoDto>();
            CreateMap<DepartamentoDto, Departamento>();
        }


    }
}
