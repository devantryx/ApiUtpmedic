using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApiUtpmedic.Models
{
    public class Medicamento
    {
        [Key]
        public int idmedicamento { get; set; }
        public string medicamento_nombre { get; set; }
        public string medicamento_presenta { get; set; }
        public string foto_url { get; set; }
        public string composicion { get; set; }
        public string contraindicaciones { get; set; }
        public string precaucion { get; set; }
    }
}
