﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApiUtpmedic.Models.Dtos
{
    public class TipoUsuarioDto
    {
        [Key]
        public int idtipousuario { get; set; }
        public string tipousuario_descripcion { get; set; }

        
    }
}
