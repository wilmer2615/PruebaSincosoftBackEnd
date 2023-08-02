using Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.Repository
{
    public interface IMateriaRepository
    {
        public Task<Materia> AddAsync(Materia materia);

        public Task<Materia> UpdateAsync(int id, Materia materia);

        public Task<Materia> RemoveAsync(int id);

        public Task<Materia> FindAsync(int id);

        public Task<IEnumerable<Materia>> GetAllAsync();
    }
}
