using AutoMapper;
using Models;
using Repository.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Logic.AnioAcademicoLogic
{
    public class AnioAcademicoLogic : IAnioAcademicoLogic
    {
        private readonly IMapper _mapper;

        private readonly IAnioAcademicoRepository _anioAcademicoRepository;

        public AnioAcademicoLogic(IMapper mapper, IAnioAcademicoRepository anioAcademicoRepository)
        {
            this._anioAcademicoRepository = anioAcademicoRepository;
            this._mapper = mapper;

        }
        public async Task<IEnumerable<AnioAcademicoModel>> GetAllAsync()
        {
            var entities = await _anioAcademicoRepository.GetAllAsync();

            var result = _mapper.Map<List<AnioAcademicoModel>>(entities);

            return result;
        }
    }
}
