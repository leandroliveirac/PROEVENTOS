using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using ProEventos.Application.Interfaces.Services;
using ProEventos.Application.Services;
using ProEventos.Domain.Interfaces.Repositories;
using ProEventos.Domain.Interfaces.Services;
using ProEventos.Domain.Services;
using ProEventos.Infra.Data.Contexts;
using ProEventos.Infra.Data.Repositories;

namespace ProEventos.API
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

            services.AddDbContext<ProEventosContext>(context => context.UseSqlite(Configuration.GetConnectionString("Default")));
            services.AddControllers()
                    .AddNewtonsoftJson(x => x.SerializerSettings.ReferenceLoopHandling = 
                            Newtonsoft.Json.ReferenceLoopHandling.Ignore);

            #region Injerção de Depedencia
            services.AddScoped<IEventoServiceApp, EventoServiceApp>();
            services.AddScoped<IEventoRepository, EventoRepository>();
            services.AddScoped<IPalestranteRepository, PalestranteRepository>();
            services.AddScoped<IEventoService, EventoService>();
            services.AddScoped<IPalestranteService, PalestranteService>();
            #endregion
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ProEventos.API", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ProEventos.API v1"));
            }

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
