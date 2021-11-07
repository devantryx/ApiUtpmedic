using ApiUtpmedic.Data;
using ApiUtpmedic.Models;
using ApiUtpmedic.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiUtpmedic.Repository
{
    public class PublicacionRepository : IPublicacionRepository
    {
        //instanciando el contexto bd
        private readonly ApplicationDbContext _bd;

        //constructor
        public PublicacionRepository(ApplicationDbContext bd)
        {
            _bd = bd;
        }

        //Metodos
        public bool ActualizarPublicacion(Publicacion publicacion)
        {
            _bd.Publicacion.Update(publicacion);
            return Guardar();
        }

        public bool BorrarPublicacion(Publicacion publicacion)
        {
            _bd.Publicacion.Remove(publicacion);
            return Guardar();
        }

        public bool CrearPublicacion(Publicacion publicacion)
        {
            _bd.Publicacion.Add(publicacion);
            return Guardar();
        }       

        public bool ExistePublicacion(int id)
        {
            return _bd.Publicacion.Any(c => c.id == id);
        }

        public Publicacion GetPublicaciones(int PublicacionId)
        {
            return _bd.Publicacion.FirstOrDefault(c => c.id == PublicacionId);
        }

        public ICollection<Publicacion> GetPublicaciones()
        {
            return _bd.Publicacion.OrderBy(c => c.mensaje).ToList();//OrderBy=devuelve de manera ascendente
        }

        public bool Guardar()
        {
            return _bd.SaveChanges() >= 0 ? true : false;
        }
    }
}
