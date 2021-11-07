using ApiUtpmedic.Data;
using ApiUtpmedic.Models;
using ApiUtpmedic.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiUtpmedic.Repository
{
    public class ClinicaRepository : IClinicaRepository
    {
        //instanciando el contexto bd
        private readonly ApplicationDbContext _bd;

        //Constructor
        public ClinicaRepository(ApplicationDbContext bd) 
        {
            _bd = bd;
        }

        public bool ActualizarClinica(Clinica clinica)
        {
            _bd.Clinica.Update(clinica);
            return Guardar();
        }

        public bool BorrarClinica(Clinica clinica)
        {
            _bd.Clinica.Remove(clinica);
            return Guardar();
        }

        public bool CrearClinica(Clinica clinica)
        {
            _bd.Clinica.Add(clinica);
            return Guardar();
        }

        public bool ExisteClinica(string clinica_nombre)
        {
            bool valor = _bd.Clinica.Any(c => c.clinica_nombre.ToLower().Trim() == clinica_nombre.ToLower().Trim());
            return valor;
        }

        public bool ExisteClinica(int idclinica)
        {
            return _bd.Clinica.Any(c => c.idclinica == idclinica);
        }

        public Clinica GetClinica(int idclinica)
        {
            return _bd.Clinica.FirstOrDefault(c => c.idclinica == idclinica);
        }

        public ICollection<Clinica> GetClinicas()
        {
            return _bd.Clinica.OrderBy(c => c.clinica_nombre).ToList();
        }

        public bool Guardar()
        {
            return _bd.SaveChanges() >= 0 ? true : false;
        }
    }
}
