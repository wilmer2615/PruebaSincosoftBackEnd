using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class ProfesorModel
    {
        public int Id { get; set; }
        [Required]
        [StringLength(200)]
        public string Nombre { get; set; }
        [Required]
        [StringLength(200)]
        public string Apellido { get; set; }
        [Required]
        [StringLength(200)]
        public string Edad { get; set; }
        [Required]
        [StringLength(200)]
        public string Direccion { get; set; }
        [Required]
        [StringLength(200)]
        public string Telefono { get; set; }
    }
}
