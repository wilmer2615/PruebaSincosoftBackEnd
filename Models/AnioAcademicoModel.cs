using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class AnioAcademicoModel
    {
        public int Id { get; set; }
        [Required]
        [StringLength(200)]
        public string Descripcion { get; set; }
    }
}
