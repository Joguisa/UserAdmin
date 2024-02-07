using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BackUserAdmin.Models
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string? Usuario { get; set; }

        [Required]
        public string? PrimerNombre { get; set; }

        public string? SegundoNombre { get; set; }

        [Required]
        public string? PrimerApellido { get; set; }

        public string? SegundoApellido { get; set; }
        [Required] // Asegúrate de agregar esta anotación si el email es requerido
        public string? Email { get; set; }

        [ForeignKey("Departamento")]
        public int IdDepartamento { get; set; }

        [ForeignKey("Cargo")]
        public int IdCargo { get; set; }

        public Departamento? Departamento { get; set; }

        public Cargo? Cargo { get; set; }
    }
}
