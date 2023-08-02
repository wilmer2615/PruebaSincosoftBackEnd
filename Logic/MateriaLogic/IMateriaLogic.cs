using Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Logic.MateriaLogic
{
    public interface IMateriaLogic
    {
        public Task<MateriaModel> AddAsync(MateriaModel materia);

        public Task<MateriaModel> RemoveAsync(int id);

        public Task<IEnumerable<MateriaModel>> GetAllAsync();

        
    }
}
