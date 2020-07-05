using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiUtpmedic.Models.Dtos
{
    public class HorarioDto
    {
        public int      idhorario { get; set; }
        public string   horario_hinicio { get; set; }
        public string   horario_hfin { get; set; }
        public string   horario_dia { get; set; }
        public int      idmedico { get; set; }
       
    }
}
