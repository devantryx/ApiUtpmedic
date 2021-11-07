using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiUtpmedic.Models.Dtos
{
    public class PersonaDto
    {
        public string persona_dni { get; set; }
        public string persona_nombres { get; set; }
        public string persona_apellidos { get; set; }
        public string fecNac { get; set; }
        public string persona_sexo { get; set; }
        public string persona_direccion { get; set; }
        public string persona_email { get; set; }
        public string persona_telefono { get; set; }
        public string persona_distrito { get; set; }

        public Paciente Paciente{ get; set; }
    }
}
