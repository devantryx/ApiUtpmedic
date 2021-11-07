using ApiUtpmedic.Models;
using ApiUtpmedic.Models.Dtos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiUtpmedic.Data
{
    public class ApplicationDbContext: DbContext
    {
        /*
         representa una sesión con la BD que se puede utilizar para consultar y guardar instancias de sus entidades en una bd.
         */
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Cita> Cita { get; set; }

        public DbSet<Clinica> Clinica { get; set; }

        public DbSet<Especialidad> Especialidad { get; set; }

        public DbSet<Medico> Medico { get; set; }

        public DbSet<Usuario> Usuario { get; set; }

        //public DbSet<UsuarioDto> UsuarioDto { get; set; }

        public DbSet<Persona> Persona { get; set; }
       
        public DbSet<Paciente> Paciente { get; set; }
        
        public DbSet<Publicacion> Publicacion { get; set; }
    }
}
