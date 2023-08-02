using Entities;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class MateriaModel
    {
        public int Id { get; set; }        
        [Required]
        [StringLength(200)]
        public string Nombre { get; set; }        
        public int IdProfesor { get; set; }

    }
}
