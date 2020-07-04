using ApiUtpmedic.Data;
using ApiUtpmedic.Models;
using ApiUtpmedic.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiUtpmedic.Repository
{
    public class PacienteRepository : IPacienteRepository
    {
        //instanciando el contexto bd
        private readonly ApplicationDbContext _bd;

        //constructor
        public PacienteRepository(ApplicationDbContext bd)
        {
            _bd = bd;
        }

        //Metodos 

        public bool ExistePaciente(int idpaciente)
        {
            return _bd.Paciente.Any(c => c.idpaciente == idpaciente);
        }


        public IEnumerable<Paciente> GetPacientePersona()
        {
            return _bd.Paciente.Include(p => p.Persona).ToList();

        }

        public IEnumerable<Paciente> GetPacienteUsuario()
        {
            return _bd.Paciente.Include(p => p.Usuario).ToList();

        }

    }
}
