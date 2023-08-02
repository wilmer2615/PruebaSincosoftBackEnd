using Entities;
using System.Collections.Generic;

namespace Models
{
    public class CalificacionModel
    {
        public int Id { get; set; }
        public int IdAlumno { get; set; }
        public int IdMateria { get; set; }
        public List<MateriaCalificada> Materias { get; set; }
        public int IdAnioAcademico { get; set; }
        public decimal CalificacionFinal { get; set; }


    }
}
