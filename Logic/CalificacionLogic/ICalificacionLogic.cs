using Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Logic.CalificacionLogic
{
    public interface ICalificacionLogic
    {
        public Task<CalificacionModel> AddAsync(CalificacionModel calificacion);

        public Task<CalificacionModel> RemoveAsync(int id);

        public Task<IEnumerable<ReporteModel>> GetAllAsync();

    }
}
