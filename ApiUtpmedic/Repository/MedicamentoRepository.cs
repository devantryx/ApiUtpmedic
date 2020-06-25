using ApiUtpmedic.Data;
using ApiUtpmedic.Models;
using ApiUtpmedic.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiUtpmedic.Repository
{
    public class MedicamentoRepository : IMedicamentoRepository
    {
        //instanciando el contexto bd
        private readonly ApplicationDbContext _bd;

        //constructor
        public MedicamentoRepository(ApplicationDbContext bd)
        {
            _bd = bd;
        }

        //Metodos
        public bool ExisteMedicamento(int idmedicamento)
        {
            return _bd.Medicamento.Any(c => c.idmedicamento == idmedicamento);
        }

        public IEnumerable<Medicamento> BuscarMedicamento(string medicamento_nombre)
        {
            IQueryable<Medicamento> query = _bd.Medicamento;
            if (!string.IsNullOrEmpty(medicamento_nombre))
            {
                query = query.Where(e => e.medicamento_nombre.Contains(medicamento_nombre));
            }

            return query.ToList();
        }


        public Medicamento GetMedicamento(int idmedicamento)
        {
            return _bd.Medicamento.FirstOrDefault(c => c.idmedicamento == idmedicamento);
        }

        public ICollection<Medicamento> GetMedicamentos()
        {
            return _bd.Medicamento.OrderBy(c => c.idmedicamento).ToList();
        }
    }
}
