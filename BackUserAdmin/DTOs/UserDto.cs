using BackUserAdmin.Models;

namespace BackUserAdmin.DTOs
{
    public class UserDto
    {
        public int? Id { get; set; }
        public string? usuario { get; set; }
        public string? primerNombre { get; set; }
        public string? segundoNombre { get; set; }
        public string? primerApellido { get; set; }
        public string? segundoApellido { get; set; }
        public string? email { get; set; }
        public int IdDepartamento { get; set; }
        public int IdCargo { get; set; }
        public Departamento? Departamento { get; set; }
        public Cargo? Cargo { get; set; }
    }
}
