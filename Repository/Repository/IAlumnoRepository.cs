using Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.Repository
{
    public interface IAlumnoRepository
    {
        public Task<Alumno> AddAsync(Alumno alumno);

        public Task<Alumno> UpdateAsync(int id, Alumno alumno);

        public Task<Alumno> RemoveAsync(int id);

        public Task<Alumno> FindAsync(int id);

        public Task<IEnumerable<Alumno>> GetAllAsync();
        
    }
}
