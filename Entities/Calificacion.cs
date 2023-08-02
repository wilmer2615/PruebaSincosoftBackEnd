using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{
    public class Calificacion
    {
        public int Id { get; set; }
        public int IdAlumno { get; set; }
        public Alumno Alumno { get; set; }

        public int IdMateria { get; set; }
        public Materia Materia { get; set; }

        public int IdAnioAcademico { get; set; }
        public AnioAcademico AnioAcademico { get; set; }
        
        public decimal CalificacionFinal { get; set; }
        

    }
}
