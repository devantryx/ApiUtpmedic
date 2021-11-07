using ApiUtpmedic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiUtpmedic.Repository.IRepository
{
  public  interface IPublicacionRepository
    {
        //Metodos que se utilizaran sobre la tabla Publicacion

        ICollection<Publicacion>    GetPublicaciones();
        Publicacion                 GetPublicaciones(int PublicacionId);
        bool                        ExistePublicacion(int id);
        bool                        CrearPublicacion(Publicacion publicacion);
        bool                        ActualizarPublicacion(Publicacion publicacion);
        bool                        BorrarPublicacion(Publicacion publicacion);
        bool                        Guardar();
    }
}
