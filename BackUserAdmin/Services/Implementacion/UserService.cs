using AutoMapper;
using BackUserAdmin.DataContext;
using BackUserAdmin.DTOs;
using BackUserAdmin.Models;
using BackUserAdmin.Services.Contrato;
using Microsoft.EntityFrameworkCore;

namespace BackUserAdmin.Services.Implementacion
{
    public class UserService : IUser
    {
        private readonly IConfiguration _configuration;
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        public UserService(AppDbContext context, IConfiguration configuration, IMapper mapper)
        {
            _context = context;
            _configuration = configuration;
            _mapper = mapper;
        }

        public async Task<List<UserDto>> GetUsers()
        {
            var users = await _context.Users!.Include(d => d.Departamento).Include(c => c.Cargo).ToListAsync();
            return _mapper.Map<List<UserDto>>(users);
        }

        public async Task<UserDto> GetUser(int id)
        {
            var user = await _context.Users!.FindAsync(id);
            return _mapper.Map<UserDto>(user);
        }

        public async Task<UserDto> AddUser(UserDto user)
        {
            var newUser = _mapper.Map<User>(user);
            _context.Users!.Add(newUser);
            await _context.SaveChangesAsync();
            return _mapper.Map<UserDto>(newUser);
        }

        public async Task<UserDto> UpdateUser(UserDto user, int id)
        {
            var userToUpdate = await _context.Users!.FindAsync(id);
            if (userToUpdate == null)
            {
                throw new ArgumentException($"El usuario con el ID {id} no existe.");
            }
            userToUpdate.Usuario = user.usuario;
            userToUpdate.PrimerNombre = user.primerNombre;
            userToUpdate.SegundoNombre = user.segundoNombre;
            userToUpdate.PrimerApellido = user.primerApellido;
            userToUpdate.SegundoApellido = user.segundoApellido;
            userToUpdate.Email = user.email;
            userToUpdate.IdDepartamento = user.IdDepartamento;
            userToUpdate.IdCargo = user.IdCargo;

            await _context.SaveChangesAsync();
            return _mapper.Map<UserDto>(userToUpdate);
        }


        public async Task<bool> DeleteUser(int id)
        {
            // Buscar el usuario por su ID
            var user = await _context.Users!.FindAsync(id);

            if (user == null)
            {
                throw new ArgumentException($"El usuario con el ID {id} no existe.");
            }

            // Eliminar el usuario del contexto
            _context.Users.Remove(user);

            // Guardar los cambios en la base de datos
            await _context.SaveChangesAsync();

            // Devolver true para indicar que la eliminación fue exitosa
            return true;
        }

    }
}
