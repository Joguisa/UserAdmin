using AutoMapper;
using BackUserAdmin.DataContext;
using BackUserAdmin.DTOs;
using BackUserAdmin.Models;
using BackUserAdmin.Services.Contrato;
using Microsoft.EntityFrameworkCore;

namespace BackUserAdmin.Services.Implementacion
{
    public class CargoService : ICargo
    {
        private readonly IConfiguration _configuration;
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public CargoService(AppDbContext context, IConfiguration configuration, IMapper mapper)
        {
            _context = context;
            _configuration = configuration;
            _mapper = mapper;
        }

        public async Task<List<CargoDto>> GetCargos()
        {
            var cargos = await _context.Cargos!.Where(c => c.Activo).ToListAsync();
            return _mapper.Map<List<CargoDto>>(cargos);
        }

        public async Task<CargoDto> GetCargo(int id)
        {
            var cargo = await _context.Cargos!.FindAsync(id);
            return _mapper.Map<CargoDto>(cargo);
        }

        public async Task<CargoDto> AddCargo(CargoDto cargo)
        {
            var newCargo = _mapper.Map<Cargo>(cargo);
            _context.Cargos!.Add(newCargo);
            await _context.SaveChangesAsync();
            return _mapper.Map<CargoDto>(newCargo);
        }

        public async Task<CargoDto> UpdateCargo(CargoDto cargo, int id)
        {
            var cargoToUpdate = await _context.Cargos!.FindAsync(id);
            if (cargoToUpdate == null)
            {
                throw new ArgumentException($"El cargo con el ID {id} no existe.");
            }

            cargoToUpdate.Codigo = cargo.codigo;
            cargoToUpdate.Nombre = cargo.nombre;
            cargoToUpdate.Activo = cargo.activo;
            cargoToUpdate.IdUsuarioCreacion = cargo.idUsuarioCreacion;

            await _context.SaveChangesAsync();
            return _mapper.Map<CargoDto>(cargoToUpdate);
        }

        public async Task<bool> DeleteCargo(int id)
        {
            var cargo = await _context.Cargos!.FindAsync(id);
            if (cargo == null)
            {
                throw new ArgumentException($"El cargo con el ID {id} no existe.");
            }

            cargo.Activo = false; // Cambiar el estado a inactivo en lugar de eliminar físicamente
            await _context.SaveChangesAsync();
            return true;
        }

    }
}
