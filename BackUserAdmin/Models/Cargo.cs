using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BackUserAdmin.Models
{
    public class Cargo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string? Codigo { get; set; }

        [Required]
        public string? Nombre { get; set; }

        public bool Activo { get; set; } = true;

        public int IdUsuarioCreacion { get; set; }
    }
}
