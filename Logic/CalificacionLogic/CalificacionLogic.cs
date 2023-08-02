using AutoMapper;
using Entities;
using Models;
using Repository.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Logic.CalificacionLogic
{
    public class CalificacionLogic : ICalificacionLogic
    {
        private readonly IMapper _mapper;

        private readonly ICalificacionRepository _calificacionRepository;

        public CalificacionLogic(IMapper mapper, ICalificacionRepository calificacionRepository)
        {
            this._calificacionRepository = calificacionRepository;
            this._mapper = mapper;

        }
        public async Task<CalificacionModel> AddAsync(CalificacionModel calificacionModel)
        {

            var response = new Calificacion();

            foreach (var calificacion in calificacionModel.Materias)
            {
                var entityMateria = await this._calificacionRepository.FindByAsignatursAsync(calificacionModel.IdAlumno, calificacionModel.IdAnioAcademico, calificacion.IdMateria);
                if (entityMateria.Count > 0)
                {
                    return null;
                }

                Calificacion entity = new()
                {
                    IdAlumno = calificacionModel.IdAlumno,
                    IdMateria = calificacion.IdMateria,
                    CalificacionFinal = calificacion.Calificacion,
                    IdAnioAcademico = calificacionModel.IdAnioAcademico

                };

                response = await _calificacionRepository.AddAsync(_mapper.Map<Calificacion>(entity));
            }

            var result = _mapper.Map<CalificacionModel>(response);

            return result;
        }        

        public async Task<IEnumerable<ReporteModel>> GetAllAsync()
        {
            var entities = await _calificacionRepository.GetAllAsync();

            var result = _mapper.Map<List<ReporteModel>>(entities);

            return result;
        }

        public async Task<CalificacionModel> RemoveAsync(int id)
        {
            var entity = await _calificacionRepository.RemoveAsync(id);

            var result = _mapper.Map<CalificacionModel>(entity);

            return result;
        }

        
    }
}
