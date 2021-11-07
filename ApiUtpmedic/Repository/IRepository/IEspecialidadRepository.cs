using ApiUtpmedic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiUtpmedic.Repository.IRepository
{
  public  interface IEspecialidadRepository
    {
        //Metodos que se utilizaran sobre la tabla Especialidad

        ICollection<Especialidad>   GetEspecialidades();
        Especialidad                GetEspecialidad(int EspecialidadId);
        bool                        ExisteEspecialidad(string nombre);
        bool                        ExisteEspecialidad(int id);
        bool                        CrearEspecialidad(Especialidad especialidad);
        bool                        ActualizarEspecialidad(Especialidad especialidad);
        bool                        BorrarEspecialidad(Especialidad especialidad);
        bool                        Guardar();
    }
}
