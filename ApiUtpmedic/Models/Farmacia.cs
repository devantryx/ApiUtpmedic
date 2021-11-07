using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApiUtpmedic.Models
{
    public class Farmacia
    {
        [Key]
        public int idfarmacia               { get; set; }
        public string farmacia_nombre       { get; set; }
        public string farmacia_direccion    { get; set; }
        public string farmacia_telefono     { get; set; }
        public string farmacia_email        { get; set; }
        public string farmacia_ruc          { get; set; }
    }
}
