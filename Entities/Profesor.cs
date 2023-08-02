using System.Collections.Generic;

namespace Entities
{
    public class Profesor
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Edad { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }

        public List<Materia> MateriasAsignadas { get; set; } = new List<Materia>();
    }
}
