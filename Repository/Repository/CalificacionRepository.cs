using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repository
{
    public class CalificacionRepository : ICalificacionRepository
    {
        private readonly AplicationDbContext _context;
        public CalificacionRepository(AplicationDbContext context)
        {
            this._context = context;
        }
        public async Task<Calificacion> AddAsync(Calificacion calificacion)
        {
            try
            {
                await this._context.Set<Calificacion>().AddAsync(calificacion);
                await this._context.SaveChangesAsync();

                return calificacion;

            }
            catch (Exception ex)
            {
                string message = ex.Message;
            }
            return null;
        }

        public async Task<Calificacion> FindAsync(int id)
        {
            return await this._context.Set<Calificacion>()
                .Include(a => a.Alumno)
                .Include(m => m.Materia)
                .Include(a => a.AnioAcademico)
                .FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task<Calificacion> FindCalificationsAsync(int id)
        {
            return await this._context.Set<Calificacion>()
                .Include(a => a.Alumno).FirstOrDefaultAsync(a => a.Alumno.Id == id);             
        }

        public async Task<List<Calificacion>> FindByAsignatursAsync(int idAlumno, int idAnio, int idMateria)
        {
             var result =  await this._context.Set<Calificacion>()
                .Include(a => a.Alumno)
                .Include(aa => aa.AnioAcademico)
                .Include(m => m.Materia)
                .Where(x => x.Alumno.Id == idAlumno && x.IdMateria == idMateria && x.IdAnioAcademico == idAnio).ToListAsync();

            return result;
        }

        public async Task<IEnumerable<Calificacion>> GetAllAsync()

        {
            try
            {
                return await this._context.Set<Calificacion>()
                .Include(a => a.Alumno)
                .Include(m => m.Materia)
                .Include(a => a.AnioAcademico)
                .Include(p => p.Materia.Profesor)
                .ToListAsync();
            }
            catch (Exception ex)
            {

                string message = ex.Message;
            }
            return null;
            
        }

        public async Task<Calificacion> RemoveAsync(int id)
        {
            var entity = await _context.Calificaciones.FirstOrDefaultAsync(x => x.Id == id);

            if (entity != null)
            {
                var result = this._context.Set<Calificacion>().Remove(entity);
                await this._context.SaveChangesAsync();

                return result.Entity;
            }
            return null;
        }

        public async Task<Calificacion> UpdateAsync(int id, Calificacion calificacion)
        {
            try
            {
                var entity = _context.Calificaciones.FirstOrDefault(x => x.Id == id);

                if (entity != null)
                {
                    entity.IdAlumno = calificacion.Id;
                    entity.IdMateria = calificacion.IdMateria;
                    entity.CalificacionFinal = calificacion.CalificacionFinal;
                    entity.AnioAcademico = calificacion.AnioAcademico;

                    _context.Calificaciones.Update(entity);
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
