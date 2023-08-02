using AutoMapper;
using Entities;
using Models;
using Repository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Logic.AlumnoLogic
{
    public class AlumnoLogic : IAlumnoLogic
    {
        private readonly IMapper _mapper;

        private readonly IAlumnoRepository _alumnoRepository;

        private readonly ICalificacionRepository _calificacionRepository;

        public AlumnoLogic(IMapper mapper, IAlumnoRepository alumnoRepository, ICalificacionRepository calificacionRepository)
        {
            this._mapper = mapper;
            this._alumnoRepository = alumnoRepository;
            this._calificacionRepository = calificacionRepository;
        }

        public async Task<AlumnoModel> AddAsync(AlumnoModel alumno)
        {
            var entity = await _alumnoRepository.AddAsync(_mapper.Map<Alumno>(alumno));

            var result = _mapper.Map<AlumnoModel>(entity);

            return result;
        }

        public async Task<AlumnoModel> RemoveAsync(int id)       
        {
            var entityAlumno = this._calificacionRepository.FindCalificationsAsync(id);
            
            if (entityAlumno.Result != null)
            {
                return null;
            }
            var entity = await _alumnoRepository.RemoveAsync(id);

            var result = _mapper.Map<AlumnoModel>(entity);

            return result;
        }

        public async Task<AlumnoModel> UpdateAsync(int id, AlumnoModel alumno)
        {
            var entity = await _alumnoRepository.UpdateAsync(id, _mapper.Map<Alumno>(alumno));

            var result = _mapper.Map<AlumnoModel>(entity);

            return result;       
        }

        public async Task<IEnumerable<AlumnoModel>> GetAllAsync()
        {
            var entities = await _alumnoRepository.GetAllAsync();

            var result = _mapper.Map<List<AlumnoModel>>(entities);

            return result;
        }

        public async Task<AlumnoModel> FindAsync(int id)
        {
            var entity = await _alumnoRepository.FindAsync(id);

            var result = _mapper.Map<AlumnoModel>(entity);

            return result;
        }
    }
}
