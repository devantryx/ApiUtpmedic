using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
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

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(Options => Options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            //inyecta la dependencia al Repository
            services.AddScoped<ICitaRepository, CitaRepository>();
            services.AddScoped<IClinicaRepository, ClinicaRepository>();
            services.AddScoped<IEspecialidadRepository, EspecialidadRepository>(); 
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<IPublicacionRepository, PublicacionRepository>();
            
            //Dependencia del token
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(Options =>
                {
                    Options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Configuration.GetSection("AppSettings:Token").Value)),
                        ValidateIssuer = false,
                        ValidateAudience = false
                    };
                });

            services.AddAutoMapper(typeof(Mappers));

            //configuracion para swagger----------
            //services.AddSwaggerGen(options => {
            //    options.SwaggerDoc("ApiUtpmedicUsuarios", new Microsoft.OpenApi.Models.OpenApiInfo()
            //    {
            //        Title = "Api Usuario",
            //        Version = "0.1",
            //        Description = "Profesor : Pedro Molina",
            //        Contact = new Microsoft.OpenApi.Models.OpenApiContact()
            //        {                       
            //            Name = "Gianmarcos - Michael - Modesto - Johanna ",
            //            Url = new Uri("https://www.utp.edu.pe/")
            //        },
            //        License = new Microsoft.OpenApi.Models.OpenApiLicense()
            //        {
            //            Name = "MIT Licencia",
            //            Url = new Uri("https://en.wikipedia.org/wiki/MIT_License")
            //        }
            //    });

            //    options.SwaggerDoc("ApiUtpmedicPublicaciones", new Microsoft.OpenApi.Models.OpenApiInfo()
            //    {
            //        Title = "Api Publicación",
            //        Version = "0.1",
            //        Description = "Profesor : Pedro Molina",
            //        Contact = new Microsoft.OpenApi.Models.OpenApiContact()
            //        {                        
            //            Name = "Gianmarcos - Michael - Modesto - Johanna ",
            //            Url = new Uri("https://www.utp.edu.pe/")
            //        },
            //        License = new Microsoft.OpenApi.Models.OpenApiLicense()
            //        {
            //            Name = "MIT Licencia",
            //            Url = new Uri("https://en.wikipedia.org/wiki/MIT_License")
            //        }
            //    });

            //    options.SwaggerDoc("ApiUtpmedicCitas", new Microsoft.OpenApi.Models.OpenApiInfo()
            //    {
            //        Title = "Api Citas",
            //        Version = "0.1",
            //        Description = "Profesor : Pedro Molina",
            //        Contact = new Microsoft.OpenApi.Models.OpenApiContact()
            //        {
            //            Name = "Gianmarcos - Michael - Modesto - Johanna ",
            //            Url = new Uri("https://www.utp.edu.pe/")
            //        },
            //        License = new Microsoft.OpenApi.Models.OpenApiLicense()
            //        {
            //            Name = "MIT Licencia",
            //            Url = new Uri("https://en.wikipedia.org/wiki/MIT_License")
            //        }
            //    });

            //    options.SwaggerDoc("ApiUtpmedicEspecialidades", new Microsoft.OpenApi.Models.OpenApiInfo()
            //    {
            //        Title = "Api Especialidades",
            //        Version = "0.1",
            //        Description = "Profesor : Pedro Molina",
            //        Contact = new Microsoft.OpenApi.Models.OpenApiContact()
            //        {
            //            Name = "Gianmarcos - Michael - Modesto - Johanna ",
            //            Url = new Uri("https://www.utp.edu.pe/")
            //        },
            //        License = new Microsoft.OpenApi.Models.OpenApiLicense()
            //        {
            //            Name = "MIT Licencia",
            //            Url = new Uri("https://en.wikipedia.org/wiki/MIT_License")
            //        }
            //    });

            //    options.SwaggerDoc("ApiUtpmedicClinicas", new Microsoft.OpenApi.Models.OpenApiInfo()
            //    {
            //        Title = "Api Clinicas",
            //        Version = "0.1",
            //        Description = "Profesor : Pedro Molina",
            //        Contact = new Microsoft.OpenApi.Models.OpenApiContact()
            //        {
            //            Name = "Gianmarcos - Michael - Modesto - Johanna ",
            //            Url = new Uri("https://www.utp.edu.pe/")
            //        },
            //        License = new Microsoft.OpenApi.Models.OpenApiLicense()
            //        {
            //            Name = "MIT Licencia",
            //            Url = new Uri("https://en.wikipedia.org/wiki/MIT_License")
            //        }
            //    });

            //    //Mostrara los comentarios ingresados en el controller en cada metodo
            //    var archivoXmlComentarios = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            //    var rutaApiComentarios = Path.Combine(AppContext.BaseDirectory, archivoXmlComentarios);
            //    options.IncludeXmlComments(rutaApiComentarios);
            //});

            //------------------------------------

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            //configuracion para swagger
            //app.UseSwagger();

            //configuracion swagger UI 
            //app.UseSwaggerUI(options =>
            //{

            //    options.SwaggerEndpoint("/swagger/ApiUtpmedicUsuarios/swagger.json", "Api Usuarios");
            //    options.SwaggerEndpoint("/swagger/ApiUtpmedicPublicaciones/swagger.json", "Api Publicaciones");                
            //    options.SwaggerEndpoint("/swagger/ApiUtpmedicCitas/swagger.json", "Api Citas");
            //    options.SwaggerEndpoint("/swagger/ApiUtpmedicEspecialidades/swagger.json", "Api Especialidades");
            //    options.SwaggerEndpoint("/swagger/ApiUtpmedicClinicas/swagger.json", "Api Clinicas");

            //    options.RoutePrefix = "";

            //});
            //

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
