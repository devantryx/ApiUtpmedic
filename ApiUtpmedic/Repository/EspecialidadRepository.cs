using ApiUtpmedic.Data;
using ApiUtpmedic.Models;
using ApiUtpmedic.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiUtpmedic.Repository
{
    public class EspecialidadRepository : IEspecialidadRepository
    {
        //instanciando el contexto bd
        private readonly ApplicationDbContext _bd;

        //constructor
        public EspecialidadRepository(ApplicationDbContext bd)
        {
            _bd = bd;
        }

        //Metodos
        public bool ActualizarEspecialidad(Especialidad especialidad)
        {
            _bd.Especialidad.Update(especialidad);
            return Guardar();
        }

        public bool BorrarEspecialidad(Especialidad especialidad)
        {
            _bd.Especialidad.Remove(especialidad);
            return Guardar();
        }

        public bool CrearEspecialidad(Especialidad especialidad)
        {
            _bd.Especialidad.Add(especialidad);
            return Guardar();
        }

        public bool ExisteEspecialidad(string nombre)
        {
            bool valor = _bd.Especialidad.Any(c => c.especialidad_nombre.ToLower().Trim() == nombre.ToLower().Trim());//ToLower=convertido a minuscula -Trim=corta espacios
            return valor;
        }

        public bool ExisteEspecialidad(int id)
        {
            return _bd.Especialidad.Any(c => c.idespecialidad == id);
        }

        public Especialidad GetEspecialidad(int EspecialidadId)
        {
            return _bd.Especialidad.FirstOrDefault(c => c.idespecialidad == EspecialidadId);
        }

        public ICollection<Especialidad> GetEspecialidades()
        {
            return _bd.Especialidad.OrderBy(c => c.especialidad_nombre).ToList();//OrderBy=devuelve de manera ascendente
        }

        public bool Guardar()
        {
            return _bd.SaveChanges() >= 0 ? true : false;
        }
    }
}
