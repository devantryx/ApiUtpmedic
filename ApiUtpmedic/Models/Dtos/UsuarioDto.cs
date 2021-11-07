using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using static ApiUtpmedic.Models.Usuario;

namespace ApiUtpmedic.Models.Dtos
{
    public class UsuarioDto
    {
        //almancena data al ingresar 

        public int          idusuario       { get; set; }

        [Required(ErrorMessage = "El usuario es obligatorio")]
        public string       usuario_user    { get; set; }

        
        public string       nombrefoto      { get; set; }

        [Required(ErrorMessage = "Id Tipo de usuario es obligatorio [1 = Administrador , 2 = Medico, 3 = Paciente]")]
        public int  idtipousuario   { get; set; }
       
        //public int idpaciente { get; set; }
        //public Paciente Paciente { get; set; }


        //public Persona Persona{ get; set; }
        //public int idpersona { get; set; }

        //public TipoUsuario TipoUsuario { get; set; }
    }
}
