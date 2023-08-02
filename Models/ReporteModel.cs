namespace Models
{
    public class ReporteModel
    {
        public int Id { get; set; }
        public string AnioAcademico { get; set; }
        public int IdentificacionAlumno { get; set; }
        public string NombreAlumno { get; set; }
        public int CodigoMateria { get; set; }
        public string NombreMateria { get; set; }
        public int IdentificacionProfesor { get; set; }
        public string NombreProfesor { get; set; }
        public string CalificacionFinal { get; set; }
        public string Aprobo { get; set; }
    }
}
