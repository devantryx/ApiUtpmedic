using ApiUtpmedic.Data;
using ApiUtpmedic.Models;
using ApiUtpmedic.Models.Dtos;
using ApiUtpmedic.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiUtpmedic.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        //instanciando el contexto bd
        private readonly ApplicationDbContext _bd;

        //constructor
        public UsuarioRepository(ApplicationDbContext bd)
        {
            _bd = bd;
        }

        //Metodos

        public bool ExisteUsuario(string usuario)
        {

            //bool valor = _bd.Usuario.Any(c => c.usuario_user.ToLower().Trim() == usuario.ToLower().Trim());  //valida letra mayuscula/minuscula
            //return valor;
            if (_bd.Usuario.Any(x => x.usuario_user == usuario))
            {

                return true;
            }
            return false;

        }

        public Usuario GetUsuario(int UsuariosId)
        {
            return _bd.Usuario.FirstOrDefault(c => c.idusuario == UsuariosId);
        }

        public ICollection<Usuario> GetUsuarios()
        {
            return _bd.Usuario.OrderBy(c => c.usuario_user).ToList();
        }

       
        public bool Guardar()
        {
            return _bd.SaveChanges() >= 0 ? true : false;
        }

        public Usuario Login(string usuario, string clave)
        {

            var user = _bd.Usuario.FirstOrDefault(x => x.usuario_user == usuario);
            if (user == null)
            {
                return null;
            }
            if (!VerificaClave(clave, user.usuario_clave, user.usuario_clave2))
            {
                return null;

            }
            return user;
        }

        //public Usuario Registro(Usuario usuario, string clave)
        //{
        //    byte[] usuario_clave, usuario_clave2;

        //    CrearClave(clave, out usuario_clave, out usuario_clave2);

        //    usuario.usuario_clave = usuario_clave;
        //    usuario.usuario_clave2 = usuario_clave2;

        //    _bd.Usuario.Add(usuario);
        //    _bd.Usuario.Add(usuario);
        //    Guardar();
        //    return usuario;
        //}


      public  Usuario  CrearUsuario(Persona persona,Usuario usuario, Paciente paciente,string clave)
        
        {            
            byte[] usuario_clave, usuario_clave2;

            CrearClave(clave, out usuario_clave, out usuario_clave2);

            usuario.usuario_clave = usuario_clave;
            usuario.usuario_clave2 = usuario_clave2;

            _bd.Persona.Add(persona);           
            _bd.Usuario.Add(usuario);
           
            Guardar();
            paciente.idpersona = persona.idpersona;
            paciente.idusuario = usuario.idusuario;
            _bd.Paciente.Add(paciente);
            Guardar();
            return usuario;
        }

       

        //Trae nformacion de usuario pasandole su dni
        public IEnumerable<Persona> TraerDatosUsuario(string dni)
        {
            IQueryable<Persona> query = _bd.Persona;
            if (!string.IsNullOrEmpty(dni))
            {
                query = query.Where(e => e.persona_dni.Contains(dni));
            }

            return query.ToList();
        }

        public IEnumerable<Paciente> GetPacientePersona(int idpaciente)
        {
            return _bd.Paciente.Include(p => p.Persona).Where(p => p.idpaciente == idpaciente).ToList();
            
        }

        public IEnumerable<Paciente> GetPacienteUsuario(int idpaciente)
        {
            return _bd.Paciente.Include(p => p.Usuario).Where(p => p.idpaciente == idpaciente).ToList();

        }

        private bool VerificaClave(string clave, byte[] usuario_clave, byte[] usuario_clave2) //hash = usuario_clave ; salt= usuario_clave2
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(usuario_clave2))
            {
                var hashCumputado = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(clave));

                for (int i = 0; i < hashCumputado.Length; i++)
                {
                    if (hashCumputado[i] != usuario_clave[i]) return false;
                }
            }
            return true;
        }

        private bool CrearClave(string clave, out byte[] usuario_clave, out byte[] usuario_clave2)//hash = usuario_clave ; salt= usuario_clave2
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                usuario_clave2 = hmac.Key;
                usuario_clave = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(clave));


            }
            return true;
        }

        
    }
}
