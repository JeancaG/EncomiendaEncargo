using System.ComponentModel.DataAnnotations;

namespace Modelo
{
    public class Usuario
    {
        [Required(ErrorMessage = "El Campo Codigo es Obligatorio")]
        public string Codigo { get; set; }
        [Required(ErrorMessage = "El Campo Nombre es Obligatorio")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "El Campo Rol es Obligatorio")]
        public string Clave { get; set; }
        public string Rol { get; set; }
        public bool EstaActivo { get; set; }
    }
}
