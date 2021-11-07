using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApiUtpmedic.Models.Dtos
{
    public class EspecialidadDto
    {
        public int      idespecialidad      { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio")]
        public string   especialidad_nombre { get; set; }
    }
}
