using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class MateriaCalificada
    {
        public int IdMateria { get; set; }
        [Required]
        public decimal Calificacion { get; set; }
    }
}
