using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiUtpmedic.Models.Dtos
{
    public class MedicamentoDto
    {
        public int idmedicamento { get; set; }
        public string medicamento_nombre { get; set; }
        public string medicamento_presenta { get; set; }

    }
}
