using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiUtpmedic.Models.Dtos
{
    public class HistorialDto
    {
        public int    idhistorial { get; set; }
        public string historial_codigo { get; set; }
        public string historial_fecha { get; set; }

      
        public Paciente Paciente { get; set; }
    }
}
