using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class AlumnoModel
    {
        public int Id { get; set; }
        
        public string Nombre { get; set; }
        
        public string Apellido { get; set; }
        
        public string Edad { get; set; }
       
        public string Direccion { get; set; }
        
        public string Telefono { get; set; }
    }
}
