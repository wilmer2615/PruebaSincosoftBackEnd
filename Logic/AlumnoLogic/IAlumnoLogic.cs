using Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Logic.AlumnoLogic
{
    public interface IAlumnoLogic
    {
        public Task<AlumnoModel> AddAsync(AlumnoModel alumno);

        public Task<AlumnoModel> UpdateAsync(int id, AlumnoModel alumno);

        public Task<AlumnoModel> RemoveAsync(int id);

        public Task<IEnumerable<AlumnoModel>> GetAllAsync();

        public Task<AlumnoModel> FindAsync(int id);
    }
}
