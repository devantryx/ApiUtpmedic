using ApiUtpmedic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiUtpmedic.Repository.IRepository
{
   public interface IMedicamentoRepository
    {
        //Metodos que se utilizaran sobre la tabla Medicamento

        ICollection<Medicamento> GetMedicamentos();
        Medicamento GetMedicamento(int idmedicamento);
        bool ExisteMedicamento(int idmedicamento);
        IEnumerable<Medicamento> BuscarMedicamento(string medicamento_nombre);
    }
}
