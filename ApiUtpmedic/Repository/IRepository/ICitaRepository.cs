using ApiUtpmedic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiUtpmedic.Repository.IRepository
{
   public interface ICitaRepository
    {
        //Metodos que se utilizaran sobre la tabla Cita

        ICollection<Cita> GetCitas();
        Cita GetCita(int idcita);
        bool ExisteCita(int idcita);
        
       
    }
}
