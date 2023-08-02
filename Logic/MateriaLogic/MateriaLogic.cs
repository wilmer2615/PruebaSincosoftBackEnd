using AutoMapper;
using Entities;
using Models;
using Repository.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Logic.MateriaLogic
{
    public class MateriaLogic : IMateriaLogic
    {
        private readonly IMapper _mapper;

        private readonly IMateriaRepository _materiaRepository;

        public MateriaLogic(IMapper mapper, IMateriaRepository materiaRepository)
        {
            this._mapper = mapper;
            this._materiaRepository = materiaRepository;
        }
        public async Task<MateriaModel> AddAsync(MateriaModel materia)
        {
            var entity = await _materiaRepository.AddAsync(_mapper.Map<Materia>(materia));

            var result = _mapper.Map<MateriaModel>(entity);

            return result;
        }

        public async Task<IEnumerable<MateriaModel>> GetAllAsync()
        {
            var entities = await _materiaRepository.GetAllAsync();

            var result = _mapper.Map<List<MateriaModel>>(entities);

            return result;
        }

        public async Task<MateriaModel> RemoveAsync(int id)
        {
            var entity = await _materiaRepository.RemoveAsync(id);

            var result = _mapper.Map<MateriaModel>(entity);

            return result;
        }

    }
}
