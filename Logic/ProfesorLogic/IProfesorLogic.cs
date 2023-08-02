using Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Logic.ProfesorLogic
{
    public interface IProfesorLogic
    {
        public Task<ProfesorModel> AddAsync(ProfesorModel profesor);

        public Task<ProfesorModel> UpdateAsync(int id, ProfesorModel profesor);

        public Task<ProfesorModel> RemoveAsync(int id);

        public Task<IEnumerable<ProfesorModel>> GetAllAsync();

        public Task<ProfesorModel> FindAsync(int id);
    }
}
