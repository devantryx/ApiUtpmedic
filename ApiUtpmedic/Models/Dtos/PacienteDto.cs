using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApiUtpmedic.Models.Dtos
{
    public class PacienteDto
    {
        [Key]
        public int idpaciente { get; set; }

        public Persona Persona { get; set; }
        public Usuario Usuario { get; set; }


    }
}
