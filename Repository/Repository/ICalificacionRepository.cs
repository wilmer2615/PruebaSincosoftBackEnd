using Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.Repository
{
    public interface ICalificacionRepository
    {
        public Task<Calificacion> AddAsync(Calificacion calificacion);

        public Task<Calificacion> UpdateAsync(int id, Calificacion calificacion);

        public Task<Calificacion> RemoveAsync(int id);

        public Task<Calificacion> FindAsync(int id);

        public Task<Calificacion> FindCalificationsAsync(int id);

        public Task<List<Calificacion>> FindByAsignatursAsync(int idAlumno, int idAnio, int idMateria);

        public Task<IEnumerable<Calificacion>> GetAllAsync();
    }
}
