using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Repository.Repository
{
    public class MateriaRepository : IMateriaRepository
    {
        private readonly AplicationDbContext _context;

        public MateriaRepository(AplicationDbContext context)
        {
            this._context = context;
        }
        public async Task<Materia> AddAsync(Materia materia)
        {
            try
            {
                await this._context.Set<Materia>().AddAsync(materia);
                await this._context.SaveChangesAsync();

                return materia;

            }
            catch (Exception ex)
            {
                string message = ex.Message;
            }
            return null;
        }

        public async Task<IEnumerable<Materia>> GetAllAsync()
        {
            return await this._context.Set<Materia>()
                .Include(p => p.Profesor).ToListAsync();
        }

        public async Task<Materia> FindAsync(int id)
        {
            return await this._context.Set<Materia>()
                .Include(p => p.Profesor)
                .FirstOrDefaultAsync(p => p.Id == id);
        }
        public async Task<Materia> RemoveAsync(int id)
        {
            var entity = await _context.Materias.FirstOrDefaultAsync(x => x.Id == id);

            if (entity != null)
            {
                var result = this._context.Set<Materia>().Remove(entity);
                await this._context.SaveChangesAsync();

                return result.Entity;
            }
            return null;
        }

        public async Task<Materia> UpdateAsync(int id, Materia materia)
        {
            try
            {
                var entity = _context.Materias.FirstOrDefault(x => x.Id == id);

                if (entity != null)
                {
                    entity.Nombre = materia.Nombre;

                    _context.Materias.Update(entity);
                    await _context.SaveChangesAsync();

                    return entity;
                }

            }
            catch (Exception ex)
            {
                string message = ex.Message;
            }
            return null;
        }
    }
}
