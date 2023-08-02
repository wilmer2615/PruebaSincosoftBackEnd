using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;



namespace Repository.Repository
{
    public class AlumnoRepository : IAlumnoRepository
    {
        private readonly AplicationDbContext _context;

        public AlumnoRepository(AplicationDbContext context)
        {
            this._context = context;
        }

        public async Task<Alumno> AddAsync(Alumno alumno)
        {
            try
            {
                await this._context.Set<Alumno>().AddAsync(alumno);
                await this._context.SaveChangesAsync();

                return alumno;

            }
            catch (Exception ex)
            {
                string message = ex.Message;                
            }
            return null;
        }

        public async Task<Alumno> RemoveAsync(int id)
        {
            var entity = await _context.Alumnos.FirstOrDefaultAsync(x => x.Id == id);

            if (entity != null)
            {
                var result = this._context.Set<Alumno>().Remove(entity);
                await this._context.SaveChangesAsync();

                return result.Entity;

                
            }
            
            return null;
           
        }

        public async Task<IEnumerable<Alumno>> GetAllAsync()
        {
            return await this._context.Set<Alumno>()
                .ToListAsync();
        }

        public async Task<Alumno> UpdateAsync(int id,Alumno alumno)
        {
            try
            {
                var entity = _context.Alumnos.FirstOrDefault(x => x.Id == id);              

                if (entity != null)
                {
                    entity.Nombre = alumno.Nombre;
                    entity.Apellido = alumno.Apellido;
                    entity.Edad = alumno.Edad;
                    entity.Direccion = alumno.Direccion;
                    entity.Telefono = alumno.Telefono;

                    _context.Alumnos.Update(entity);
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

        public async Task<Alumno> FindAsync(int id)
        {
           var result = await this._context.Alumnos               
                .FirstOrDefaultAsync(a => a.Id == id);
            return result;
        }

        
    }
}
