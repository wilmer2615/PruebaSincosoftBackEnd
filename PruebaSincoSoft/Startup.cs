using Logic;
using Logic.AlumnoLogic;
using Logic.AnioAcademicoLogic;
using Logic.CalificacionLogic;
using Logic.MateriaLogic;
using Logic.ProfesorLogic;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Repository;
using Repository.Repository;

namespace PruebaSincoSoft
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "PruebaSincoSoft", Version = "v1" });
            });

            services.AddCors(options =>
            {
                options.AddPolicy("AllowWebApp",
                    builder =>
                    {
                        builder.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader();
                    });
            });

            // Configurar AutoMapper
            services.AddAutoMapper(typeof(AutoMapperProfile));

            // Se realiza la configura de la inyección de dependencias.
            services.AddScoped<IAlumnoRepository, AlumnoRepository>();
            services.AddScoped<IProfesorRepository, ProfesorRepository>();
            services.AddScoped<IMateriaRepository, MateriaRepository>();
            services.AddScoped<ICalificacionRepository, CalificacionRepository>();
            services.AddScoped<IAnioAcademicoRepository, AnioAcademicoRepository>();


            services.AddScoped<IAlumnoLogic, AlumnoLogic>();
            services.AddScoped<IProfesorLogic, ProfesorLogic>();
            services.AddScoped<IMateriaLogic, MateriaLogic>();
            services.AddScoped<ICalificacionLogic, CalificacionLogic>();
            services.AddScoped<IAnioAcademicoLogic, AnioAcademicoLogic>();


            services.AddDbContext<AplicationDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DevConnection")));

          
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "PruebaSincoSoft v1"));
            }

            app.UseCors("AllowWebApp");

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
