using ApiUtpmedic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiUtpmedic.Repository.IRepository
{
   public interface IHorarioRepository
    {

        //Metodos que se utilizaran sobre la tabla Horario

        IEnumerable<Horario> GetHorariosMedico();
        Horario GetHorarioMedico(int idhorario);
        bool ExisteHorarioMedico(int idhorario);
    }
}
