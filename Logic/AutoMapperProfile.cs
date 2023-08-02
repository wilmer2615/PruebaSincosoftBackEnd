using AutoMapper;
using Entities;
using Models;

namespace Logic
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            /// *************************************************** 
            /// Configuracion de mapeos modelo y entidad Alumno
            /// *************************************************** 
            CreateMap<AlumnoModel, Alumno>()
                .ReverseMap();


            /// *************************************************** 
            /// Configuracion de mapeos modelo y entidad Profesor
            /// *************************************************** 
            CreateMap<ProfesorModel, Profesor>()
                .ReverseMap();

            /// *************************************************** 
            /// Configuracion de mapeos modelo y entidad Materia
            /// *************************************************** 
            CreateMap<MateriaModel, Materia>()
                .ReverseMap();

            /// *************************************************** 
            /// Configuracion de mapeos modelo y entidad Calificacion
            /// *************************************************** 
            CreateMap<CalificacionModel, Calificacion>()
                .ReverseMap();

            /// *************************************************** 
            /// Configuracion de mapeos modelo y entidad Calificacion
            /// *************************************************** 
            CreateMap<AnioAcademicoModel, AnioAcademico>()
                .ReverseMap();

            /// *************************************************** 
            /// Configuracion de mapeos modelo y entidad Calificacion
            /// *************************************************** 

            CreateMap<Calificacion, ReporteModel>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.AnioAcademico, opt => opt.MapFrom(src => src.AnioAcademico.Descripcion))
                .ForMember(dest => dest.IdentificacionAlumno, opt => opt.MapFrom(src => src.IdAlumno))
                .ForMember(dest => dest.NombreAlumno, opt => opt.MapFrom(src => $"{src.Alumno.Nombre} {src.Alumno.Apellido}"))
                .ForMember(dest => dest.CodigoMateria, opt => opt.MapFrom(src => src.Materia.Id))
                .ForMember(dest => dest.NombreMateria, opt => opt.MapFrom(src => src.Materia.Nombre))
                .ForMember(dest => dest.IdentificacionProfesor, opt => opt.MapFrom(src => src.Materia.Profesor.Id))
                .ForMember(dest => dest.NombreProfesor, opt => opt.MapFrom(src => $"{src.Materia.Profesor.Nombre} {src.Materia.Profesor.Apellido}"))
                .ForMember(dest => dest.CalificacionFinal, opt => opt.MapFrom(src => src.CalificacionFinal))
                .ForMember(dest => dest.Aprobo, opt => opt.MapFrom(src => (src.CalificacionFinal > 3)?"Si":"No"))
                .ReverseMap();

        }
    }
}
