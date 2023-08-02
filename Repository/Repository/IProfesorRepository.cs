using Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.Repository
{
    public interface IProfesorRepository
    {
        public Task<Profesor> AddAsync(Profesor profesor);

        public Task<Profesor> UpdateAsync(int id, Profesor profesor);

        public Task<Profesor> RemoveAsync(int id);

        public Task<Profesor> FindAsync(int id);

        public Task<IEnumerable<Profesor>> GetAllAsync();
    }
}
