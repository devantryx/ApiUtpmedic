using ApiUtpmedic.Models;
using ApiUtpmedic.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiUtpmedic.Repository.IRepository
{
   public interface IUsuarioRepository
    {
        //Metodos que se utilizaran sobre la tabla Usuario

        ICollection<Usuario>    GetUsuarios();
        
        Usuario                 GetUsuario(int UsuarioId);

        bool                    ExisteUsuario(string usuario);

        Usuario CrearUsuario(Persona persona, Usuario usuario, Paciente paciente, string clave);
        
        IEnumerable<Persona> TraerDatosUsuario(string dni);

        //--------------------------------------------------------
        IEnumerable<Paciente> GetPacientePersona(int idpaciente);
        IEnumerable<Paciente> GetPacienteUsuario(int idpaciente);
        //--------------------------------------------------------

        Usuario Login(string usuario, string clave);

        bool   Guardar();
    }
}
