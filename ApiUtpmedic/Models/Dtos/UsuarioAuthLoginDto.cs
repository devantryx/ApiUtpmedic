using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApiUtpmedic.Models.Dtos
{
    public class UsuarioAuthLoginDto
    {
        [Required(ErrorMessage = "El usuario es obligatorio")]
        public string usuario { get; set; }
        [Required(ErrorMessage = "La contraseña es obligatorio")]
        public string clave { get; set; }
    }
}
