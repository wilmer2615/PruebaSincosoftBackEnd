using AutoMapper;
using Entities;
using Models;
using Repository.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Logic.ProfesorLogic
{
    public class ProfesorLogic : IProfesorLogic
    {
        private readonly IMapper _mapper;

        private readonly IProfesorRepository _profesorRepository;
        public ProfesorLogic(IMapper mapper, IProfesorRepository profesorRepository) 
        {
            this._mapper = mapper;
            this._profesorRepository = profesorRepository;
        }
        public async Task<ProfesorModel> AddAsync(ProfesorModel profesor)
        {
            var entity = await _profesorRepository.AddAsync(_mapper.Map<Profesor>(profesor));

            var result = _mapper.Map<ProfesorModel>(entity);

            return result;
        }

        public async Task<ProfesorModel> FindAsync(int id)
        {
            var entity = await _profesorRepository.FindAsync(id);

            var result = _mapper.Map<ProfesorModel>(entity);

            return result;
        }

        public async Task<IEnumerable<ProfesorModel>> GetAllAsync()
        {
            var entities = await _profesorRepository.GetAllAsync();

            var result = _mapper.Map<List<ProfesorModel>>(entities);

            return result;
        }

        public async Task<ProfesorModel> RemoveAsync(int id)
        {
            var entity = await _profesorRepository.RemoveAsync(id);

            var result = _mapper.Map<ProfesorModel>(entity);

            return result;
        }

        public async Task<ProfesorModel> UpdateAsync(int id, ProfesorModel profesor)
        {
            var entity = await _profesorRepository.UpdateAsync(id, _mapper.Map<Profesor>(profesor));

            var result = _mapper.Map<ProfesorModel>(entity);

            return result;
        }
    }
}
