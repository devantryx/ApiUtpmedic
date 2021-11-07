using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApiUtpmedic.Models.Dtos
{
    public class UsuarioAuthDto
    {
        [Key]
        public int id { get; set; }

        [Required(ErrorMessage = "El usuario es obligatorio")]
        public string usuario { get; set; }

        [Required(ErrorMessage = "La contraseña es obligatorio")]
        [StringLength(25, MinimumLength = 4, ErrorMessage = "La contraseña debe estar entre 4 y 25 caracteres")]
        public string clave { get; set; }
    }
}
