using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApiUtpmedic.Data;
using ApiUtpmedic.Mapper;
using ApiUtpmedic.Repository;
using ApiUtpmedic.Repository.IRepository;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;

namespace ApiUtpmedic
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container
        public void ConfigureServices(IServiceCollection services)
        {
            //agrega la cadena de conexion con la bd
            services.AddDbContext<ApplicationDbContext>(Options => Options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            //inyecta la dependencia al Repository
            services.AddScoped<ICitaRepository, CitaRepository>();
            services.AddScoped<IClinicaRepository, ClinicaRepository>();
            services.AddScoped<IEspecialidadRepository, EspecialidadRepository>();
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<IPublicacionRepository, PublicacionRepository>();
            services.AddScoped<IMedicamentoRepository, MedicamentoRepository>();
            services.AddScoped<IMedicoRepository, MedicoRepository>();
            services.AddScoped<IPacienteRepository, PacienteRepository>();
            services.AddScoped<IHorarioRepository, HorarioRepository>();

            //Dependencia del token
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(Options =>
                {
                    Options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Configuration.GetSection("AppSettings:Token").Value)),
                        ValidateIssuer = true,
                        ValidateAudience = true
                    };
                });

            services.AddAutoMapper(typeof(Mappers));

            services.AddControllers();
            ConfigureSwagger(services);
           
        }

        private static void ConfigureSwagger(IServiceCollection services)
        {
            //configurar swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("ApiUsuarios", new Microsoft.OpenApi.Models.OpenApiInfo        { Title = "ApiUsuarios",        Version = "v1" ,Description="Backend Usuario", Contact=new                  Microsoft.OpenApi.Models.OpenApiContact() { Email="info@utpmedic.com",Name="UTPMEDIC", Url=new Uri("https://www.utp.edu.pe/") } });
                c.SwaggerDoc("ApiCitas",    new Microsoft.OpenApi.Models.OpenApiInfo        { Title = "ApiCitas",           Version = "v1", Description = "Backend Citas", Contact = new              Microsoft.OpenApi.Models.OpenApiContact() { Email = "info@utpmedic.com", Name = "UTPMEDIC", Url = new Uri("https://www.utp.edu.pe/") } });
                c.SwaggerDoc("ApiClinicas", new Microsoft.OpenApi.Models.OpenApiInfo        { Title = "ApiClinicas",        Version = "v1", Description = "Backend Clinicas", Contact = new             Microsoft.OpenApi.Models.OpenApiContact() { Email = "info@utpmedic.com", Name = "UTPMEDIC", Url = new Uri("https://www.utp.edu.pe/") } });
                
                c.SwaggerDoc("ApiEspecialidades", new Microsoft.OpenApi.Models.OpenApiInfo  { Title = "ApiEspecialidades",  Version = "v1", Description = "Backend Especialidades", Contact = new    Microsoft.OpenApi.Models.OpenApiContact() { Email = "info@utpmedic.com",Name = "UTPMEDIC", Url = new Uri("https://www.utp.edu.pe/") } });

                c.SwaggerDoc("ApiMedicos", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "ApiMedicos", Version = "v1", Description = "Backend Medicos", Contact = new Microsoft.OpenApi.Models.OpenApiContact() { Email = "info@utpmedic.com", Name = "UTPMEDIC", Url = new Uri("https://www.utp.edu.pe/") } });

                c.SwaggerDoc("ApiPacientes", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "ApiPacientes", Version = "v1", Description = "Backend Pacientes", Contact = new Microsoft.OpenApi.Models.OpenApiContact() { Email = "info@utpmedic.com", Name = "UTPMEDIC", Url = new Uri("https://www.utp.edu.pe/") } });

                c.SwaggerDoc("ApiHorariosMedico", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "ApiHorariosMedico", Version = "v1", Description = "Backend Horarios Medico", Contact = new Microsoft.OpenApi.Models.OpenApiContact() { Email = "info@utpmedic.com", Name = "UTPMEDIC", Url = new Uri("https://www.utp.edu.pe/") } });

                c.SwaggerDoc("ApiMedicamentos",   new Microsoft.OpenApi.Models.OpenApiInfo  { Title = "ApiMedicamentos",    Version = "v1", Description = "Backend Medicamentos", Contact = new    Microsoft.OpenApi.Models.OpenApiContact() { Email = "info@utpmedic.com",Name = "UTPMEDIC", Url = new Uri("https://www.utp.edu.pe/") } });
                c.SwaggerDoc("ApiPublicaciones",  new Microsoft.OpenApi.Models.OpenApiInfo  { Title = "ApiPublicaciones",   Version = "v1", Description = "Backend Publicaciones", Contact = new    Microsoft.OpenApi.Models.OpenApiContact() { Email = "info@utpmedic.com",Name = "UTPMEDIC", Url = new Uri("https://www.utp.edu.pe/") } });

            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //swagger
            app.UseSwagger();
            app.UseSwaggerUI(c => {
                c.SwaggerEndpoint("/swagger/ApiUsuarios/swagger.json", "ApiUsuarios");
                c.SwaggerEndpoint("/swagger/ApiCitas/swagger.json", "ApiCitas");
                c.SwaggerEndpoint("/swagger/ApiClinicas/swagger.json", "ApiClinicas");
                c.SwaggerEndpoint("/swagger/ApiEspecialidades/swagger.json", "ApiEspecialidades");
                c.SwaggerEndpoint("/swagger/ApiMedicos/swagger.json", "ApiMedicos");
                c.SwaggerEndpoint("/swagger/ApiPacientes/swagger.json", "ApiPacientes");
                c.SwaggerEndpoint("/swagger/ApiHorariosMedico/swagger.json", "ApiHorariosMedico");
                c.SwaggerEndpoint("/swagger/ApiMedicamentos/swagger.json", "ApiMedicamentos");
                c.SwaggerEndpoint("/swagger/ApiPublicaciones/swagger.json", "ApiPublicaciones");
                
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
         

            app.UseRouting();
            //Autorizacion  y autenticacion a ciertas funcionalidades
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
