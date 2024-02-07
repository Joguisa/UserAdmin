namespace BackUserAdmin.DTOs
{
    public class CargoDto
    {
        public int? Id { get; set; }
        public string? codigo { get; set; }
        public string? nombre { get; set; }
        public bool activo { get; set; }
        public int idUsuarioCreacion { get; set; }
    }
}
