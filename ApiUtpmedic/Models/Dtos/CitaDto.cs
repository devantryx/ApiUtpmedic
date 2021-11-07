using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApiUtpmedic.Models.Dtos
{
    public class CitaDto
    {
        public int idcita { get; set; }
        public int idpaciente { get; set; }
        public int idhorario { get; set; }
    }
}
