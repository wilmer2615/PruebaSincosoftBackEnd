using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Entities
{
    public class Materia
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int IdProfesor { get; set; }
        public Profesor Profesor { get; set; }
        public List<Calificacion> Calificaciones { get; set; } = new List<Calificacion>();

    }
}
