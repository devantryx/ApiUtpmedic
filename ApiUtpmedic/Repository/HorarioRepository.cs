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
    public class HorarioRepository : IHorarioRepository

    {
        //instanciando el contexto bd
        private readonly ApplicationDbContext _bd;

        //constructor
        public HorarioRepository(ApplicationDbContext bd)
        {
            _bd = bd;
        }


        public bool ExisteHorarioMedico(int idhorario)
        {
            return _bd.Horario.Any(c => c.idhorario== idhorario);
        }

        public Horario GetHorarioMedico(int idhorario)
        {
            return _bd.Horario.FirstOrDefault(c => c.idhorario == idhorario);
        }

 
        public IEnumerable<Horario> GetHorariosMedico()
        {
            return _bd.Horario.Include(p => p.Medico).ToList();

        }
    }
}
