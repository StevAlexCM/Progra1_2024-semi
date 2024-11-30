using System.ComponentModel.DataAnnotations;

namespace sistema_academico.Models
{
    public class usuario
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string NombreUsuario { get; set; }

        [Required]
        public string Contraseña { get; set; }
    }
}
