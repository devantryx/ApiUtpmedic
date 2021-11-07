using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApiUtpmedic.Models
{
    public class TipoUsuario
    {
        [Key]
        public int idtipousuario                { get; set; }
        public string tipousuario_descripcion   { get; set; }
    }
}
