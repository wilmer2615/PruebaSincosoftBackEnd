using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Repository.Repository
{
    public class ProfesorRepository : IProfesorRepository
    {
        private readonly AplicationDbContext _context;

        public ProfesorRepository(AplicationDbContext context)
        {
            this._context = context;
        }
        public async Task<Profesor> AddAsync(Profesor profesor)
        {
            try
            {
                await this._context.Set<Profesor>().AddAsync(profesor);
                await this._context.SaveChangesAsync();

                return profesor;

            }
            catch (Exception ex)
            {
                string message = ex.Message;                
            }
            return null;
        }

        public async Task<Profesor> FindAsync(int id)
        {
            return await this._context.Set<Profesor>()
                 .FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task<IEnumerable<Profesor>> GetAllAsync()
        {
            return await this._context.Set<Profesor>()
                .ToListAsync();
        }

        public async Task<Profesor> RemoveAsync(int id)
        {
            var entity = await _context.Profesores.FirstOrDefaultAsync(x => x.Id == id);

            if (entity != null)
            {
                var result = this._context.Set<Profesor>().Remove(entity);
                await this._context.SaveChangesAsync();

                return result.Entity;
            }
            return null;
        }

        public async Task<Profesor> UpdateAsync(int id, Profesor profesor)
        {
            try
            {
                var entity = _context.Profesores.FirstOrDefault(x => x.Id == id);

                if (entity != null)
                {
                    entity.Nombre = profesor.Nombre;
                    entity.Apellido = profesor.Apellido;
                    entity.Edad = profesor.Edad;
                    entity.Direccion = profesor.Direccion;
                    entity.Telefono = profesor.Telefono;

                    _context.Profesores.Update(entity);
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
