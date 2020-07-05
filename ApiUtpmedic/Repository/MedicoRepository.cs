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
    public class MedicoRepository : IMedicoRepository
    {
        //instanciando el contexto bd
        private readonly ApplicationDbContext _bd;

        //constructor
        public MedicoRepository(ApplicationDbContext bd)
        {
            _bd = bd;
        }

        //Metodos
        public ICollection<Medico> GetMedicos()
        {
            return _bd.Medico.OrderBy(c => c.idmedico).ToList();
        }

        public Medico GetMedico(int idmedico)
        {
            return _bd.Medico.FirstOrDefault(c => c.idmedico == idmedico);
        }

        public bool ExisteMedico(int idmedico)
        {
            return _bd.Medico.Any(c => c.idmedico == idmedico);
        }


        public IEnumerable<Medico> GetMedicoPersona()
        {
            return _bd.Medico.Include(p => p.Persona )
                             .Include(p=> p.Especialidad)
                             .ToList();

        }

    }
}
