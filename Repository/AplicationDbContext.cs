using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Repository
{
    public class AplicationDbContext : DbContext
    {
        private readonly IConfiguration Config;

        public DbSet<Alumno> Alumnos { get; set; }
        public DbSet<Materia> Materias { get; set; }
        public DbSet<Profesor> Profesores { get; set; }
        public DbSet<Calificacion> Calificaciones { get; set; }
        public DbSet<AnioAcademico> AnioAcademicos { get; set; }


        public AplicationDbContext(DbContextOptions<AplicationDbContext> options, IConfiguration config) : base(options)
        {
            Config = config;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);

            // Configuración de la relaciones entre los diferentes entidades

            modelBuilder.Entity<Profesor>()
                .HasMany(p => p.MateriasAsignadas)
                .WithOne(m => m.Profesor)
                .HasForeignKey(m => m.IdProfesor);

            modelBuilder.Entity<Materia>()
                .HasMany(m => m.Calificaciones)
                .WithOne(c => c.Materia)
                .HasForeignKey(c => c.IdMateria);

            modelBuilder.Entity<Alumno>()
                .HasMany(a => a.Calificaciones)
                .WithOne(c => c.Alumno)
                .HasForeignKey(c => c.IdAlumno);           

            modelBuilder.Entity<AnioAcademico>()
                .HasMany(aa => aa.Calificaciones)
                .WithOne(c => c.AnioAcademico)
                .HasForeignKey(c => c.IdAnioAcademico);

            // Relación muchos a muchos entre Alumno y Materia a través de la entidad de unión Calificacion
            modelBuilder.Entity<Calificacion>()
                .HasKey(c => c.Id);

            modelBuilder.Entity<Calificacion>()
                .HasOne(c => c.Alumno)
                .WithMany(a => a.Calificaciones)
                .HasForeignKey(c => c.IdAlumno);

            modelBuilder.Entity<Calificacion>()
                .HasOne(c => c.Materia)
                .WithMany(m => m.Calificaciones)
                .HasForeignKey(c => c.IdMateria);


        }

    }
}
