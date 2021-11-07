using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ApiUtpmedic.Models
{
    public class Recibo
    {
        [Key]
        public int      idrecibo        { get; set; }
        public string   recibo_tipo     { get; set; }
        public string   recibo_monto    { get; set; }
        public string   recibo_estado   { get; set; }

        //relacion entre Recibo y Cita
        [ForeignKey("idcita")]
        public Cita Cita                { get; set; }
    }
}
