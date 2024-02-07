using BackUserAdmin.DTOs;

namespace BackUserAdmin.Services.Contrato
{
    public interface ICargo
    {
        Task<List<CargoDto>> GetCargos();
        Task<CargoDto> GetCargo(int id);
        Task<CargoDto> AddCargo(CargoDto cargo);
        Task<CargoDto> UpdateCargo(CargoDto cargo, int id);
        Task<bool> DeleteCargo(int id);
    }
}
