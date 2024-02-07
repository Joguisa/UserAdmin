using BackUserAdmin.DTOs;

namespace BackUserAdmin.Services.Contrato
{
    public interface IDepartamento
    {
        Task<List<DepartamentoDto>> GetDepartamentos();
        Task<DepartamentoDto> GetDepartamento(int id);
        Task<DepartamentoDto> AddDepartamento(DepartamentoDto departamento);
        Task<DepartamentoDto> UpdateDepartamento(DepartamentoDto departamento, int id);
        Task<bool> DeleteDepartamento(int id);
    }
}
