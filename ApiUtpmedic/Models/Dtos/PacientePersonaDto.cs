using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApiUtpmedic.Models.Dtos
{
    public class PacientePersonaDto
    {
        [Key]
        public int idpaciente { get; set; }

        public PersonaDto Persona { get; set; }

    }
}
