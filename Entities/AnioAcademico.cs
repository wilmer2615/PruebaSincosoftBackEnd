using System.Collections.Generic;

namespace Entities
{
    public class AnioAcademico
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }

        public List<Calificacion> Calificaciones { get; set; } = new List<Calificacion>();
    }
}
