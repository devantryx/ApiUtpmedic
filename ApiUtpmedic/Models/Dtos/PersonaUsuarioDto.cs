using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApiUtpmedic.Models.Dtos
{
    public class PersonaUsuarioDto
    {
        [Key]
        public int idpaciente { get; set; }

        public int idpersona { get; set; }

        public int idusuario { get; set; }
    }
}
