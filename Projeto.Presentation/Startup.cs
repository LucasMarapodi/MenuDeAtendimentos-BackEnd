using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Projeto.Application.Contracts;
using Projeto.Application.Services;
using Projeto.Domain.Contracts.Repositories;
using Projeto.Domain.Contracts.Services;
using Projeto.Domain.Services;
using Projeto.Infra.Data.Contexts;
using Projeto.Infra.Data.Repositories;

namespace Projeto.Presentation
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

            services.AddSwaggerGen(s =>
            {
                s.SwaggerDoc("v1",
                    new OpenApiInfo
                    {
                        Title = "API para Controle de Consultas entre medicos e pacientes.",
                        Version = "v1",
                        Description = "Projeto desenvolvido em NET CORE 3.1 API com EntityFramework e usando o padrão DDD (Domain Driven Design)",
                        Contact = new OpenApiContact
                        {
                            Name = "COTI Informática - Curso de C# WebDeveloper",
                            Url = new Uri("http://wwww.cotiinformatica.com.br"),
                            Email = "contato@cotiinformatica.com.br"
                        }
                    });
            });

            services.AddDbContext<DataContext>(d => d.UseSqlServer(Configuration.GetConnectionString("ProjetoFinalDDD")));

            services.AddTransient<IMedicoApplicationService, MedicoApplicationService>();
            services.AddTransient<IPacienteApplicationService, PacienteApplicationService>();
            services.AddTransient<IAtendimentoApplicationService, AtendimentoApplicationService>();

            services.AddTransient<IMedicoDomainService, MedicoDomainService>();
            services.AddTransient<IPacienteDomainService, PacienteDomainService>();
            services.AddTransient<IAtendimentoDomainService, AtendimentoDomainService>();

            services.AddTransient<IMedicoRepository, MedicoRepository>();
            services.AddTransient<IPacienteRepository, PacienteRepository>();
            services.AddTransient<IAtendimentoRepository, AtendimentoRepository>();

            services.AddCors(
                 s => s.AddPolicy("DefaultPolicy",
                 builder => {
                     builder.AllowAnyOrigin()
                     .AllowAnyMethod()
                     .AllowAnyHeader();
 }));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseCors("DefaultPolicy");

            app.UseAuthorization();

            app.UseSwagger();
            app.UseSwaggerUI(s => { s.SwaggerEndpoint("/swagger/v1/swagger.json", "Projeto"); });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
