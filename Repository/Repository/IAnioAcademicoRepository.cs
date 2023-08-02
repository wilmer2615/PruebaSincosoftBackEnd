using Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.Repository
{
    public interface IAnioAcademicoRepository
    {
        public Task<IEnumerable<AnioAcademico>> GetAllAsync();
    }
}
