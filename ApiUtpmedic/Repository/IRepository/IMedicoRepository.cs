using ApiUtpmedic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiUtpmedic.Repository.IRepository
{
   public interface IMedicoRepository
    {
        //Metodos que se utilizaran sobre la tabla Medico

        ICollection<Medico> GetMedicos();
        Medico GetMedico(int idmedico);
        bool ExisteMedico(int idmedico);
    }
}
