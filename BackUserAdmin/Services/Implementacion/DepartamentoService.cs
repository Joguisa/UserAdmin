using AutoMapper;
using BackUserAdmin.DataContext;
using BackUserAdmin.DTOs;
using BackUserAdmin.Models;
using BackUserAdmin.Services.Contrato;
using Microsoft.EntityFrameworkCore;

namespace BackUserAdmin.Services.Implementacion
{
    public class DepartamentoService : IDepartamento
    {
        private readonly IConfiguration _configuration;
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public DepartamentoService(AppDbContext context, IConfiguration configuration, IMapper mapper)
        {
            _context = context;
            _configuration = configuration;
            _mapper = mapper;
        }
        public async Task<List<DepartamentoDto>> GetDepartamentos()
        {
            var departamentos = await _context.Departamentos!.Where(d => d.Activo).ToListAsync();
            return _mapper.Map<List<DepartamentoDto>>(departamentos);
        }
        public async Task<DepartamentoDto> GetDepartamento(int id)
        {
            var departamento = await _context.Departamentos!.FindAsync(id);
            return _mapper.Map<DepartamentoDto>(departamento);
        }
        public async Task<DepartamentoDto> AddDepartamento(DepartamentoDto departamento)
        {
            var newDepartamento = _mapper.Map<Departamento>(departamento);
            _context.Departamentos!.Add(newDepartamento);
            await _context.SaveChangesAsync();
            return _mapper.Map<DepartamentoDto>(newDepartamento);

        }
        public async Task<DepartamentoDto> UpdateDepartamento(DepartamentoDto departamento, int id)
        {
            var departamentoToUpdate = await _context.Departamentos!.FindAsync(id);
            if (departamentoToUpdate == null)
            {
                throw new ArgumentException($"El departamento con el ID {id} no existe.");
            }

            departamentoToUpdate.Codigo = departamento.codigo;
            departamentoToUpdate.Nombre = departamento.nombre;
            departamentoToUpdate.Activo = departamento.activo;
            departamentoToUpdate.IdUsuarioCreacion = departamento.idUsuarioCreacion;

            await _context.SaveChangesAsync();
            return _mapper.Map<DepartamentoDto>(departamentoToUpdate);

        }
        public async Task<bool> DeleteDepartamento(int id)
        {
            var departamento = await _context.Departamentos!.FindAsync(id);
            if (departamento == null)
            {
                return false;
            }

            departamento.Activo = false;
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
