using Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.Repository
{
    public class AnioAcademicoRepository : IAnioAcademicoRepository
    {
        private readonly AplicationDbContext _context;

        public AnioAcademicoRepository(AplicationDbContext context)
        {
            this._context = context;
        }
        public async Task<IEnumerable<AnioAcademico>> GetAllAsync()
        {
            return await this._context.Set<AnioAcademico>()
                .ToListAsync();
        }
    }
}
