using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApiUtpmedic.Models.Dtos
{
    public class PacienteUsuarioDto
    {
        [Key]
        public int idpaciente { get; set; }

        public UsuarioDto Usuario { get; set; }

    }
}
