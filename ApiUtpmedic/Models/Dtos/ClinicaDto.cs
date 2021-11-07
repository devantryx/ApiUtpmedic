using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApiUtpmedic.Models.Dtos
{
    public class ClinicaDto
    {
        public int idclinica { get; set; }

        [Required(ErrorMessage = "El nombre de la clinica es obligatorio")]
        public string clinica_nombre { get; set; }

        [Required(ErrorMessage = "La dirección de la clinica es obligatorio")]
        public string clinica_direccion { get; set; }

        [Required(ErrorMessage = "Número de teléfono de la clinica es obligatorio")]
        public string clinica_telefono { get; set; }
        
        public string clinica_email { get; set; }

        [Required(ErrorMessage = "El Ruc de la clinica es obligatorio")]
        public string clinica_ruc { get; set; }

        [Required(ErrorMessage = "El distrito de la clinica es obligatorio")]
        public string clinica_distrito { get; set; }

    }
}
