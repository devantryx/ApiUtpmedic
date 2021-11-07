using ApiUtpmedic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiUtpmedic.Repository.IRepository
{
  public  interface IClinicaRepository
    {
        //Metodos que se utilizaran sobre la tabla Clinica

        ICollection<Clinica> GetClinicas();
        Clinica GetClinica(int idclinica);
        bool ExisteClinica(string clinica_nombre);
        bool ExisteClinica(int idclinica);
        bool CrearClinica(Clinica clinica);
        bool ActualizarClinica(Clinica clinica);
        bool BorrarClinica(Clinica clinica);
        bool Guardar();
    }
}
