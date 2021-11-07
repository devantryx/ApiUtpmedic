using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ApiUtpmedic.Models
{
    public class Pago
    {
        [Key]
        public int idpago                   { get; set; }
        public string pago_metodo           { get; set; }
        public string pago_tarjetaempresa   { get; set; }
        public string pago_monto            { get; set; }

        //relacion entre Pago y Recibo
        [ForeignKey("idrecibo")]
        public Recibo Recibo                { get; set; }
    }
}
