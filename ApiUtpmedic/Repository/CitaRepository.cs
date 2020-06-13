using ApiUtpmedic.Data;
using ApiUtpmedic.Models;
using ApiUtpmedic.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiUtpmedic.Repository
{
    public class CitaRepository : ICitaRepository
    {
        //instanciando el contexto bd
        private readonly ApplicationDbContext _bd;

        //constructor
        public CitaRepository(ApplicationDbContext bd)
        {
            _bd = bd;
        }

        //Metodos
        public ICollection<Cita> GetCitas()
        {
            return _bd.Cita.OrderBy(c => c.idcita).ToList();
        }

        public Cita GetCita(int idcita)
        {
            return _bd.Cita.FirstOrDefault(c => c.idcita == idcita);
        }

        public bool ExisteCita(int idcita)
        {
            return _bd.Cita.Any(c => c.idcita == idcita);
        }
    }
}
