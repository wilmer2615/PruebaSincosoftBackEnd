using Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Logic.AnioAcademicoLogic
{
    public interface IAnioAcademicoLogic
    {
        public Task<IEnumerable<AnioAcademicoModel>> GetAllAsync();
    }
}
