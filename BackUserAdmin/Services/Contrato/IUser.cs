using BackUserAdmin.DTOs;
using BackUserAdmin.Models;

namespace BackUserAdmin.Services.Contrato
{
    public interface IUser
    {
        Task<List<UserDto>> GetUsers();
        Task<UserDto> GetUser(int id);
        Task<UserDto> AddUser(UserDto user);
        Task<UserDto> UpdateUser(UserDto user, int id);
        Task<bool> DeleteUser(int id);
    }
}
