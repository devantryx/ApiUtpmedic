using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiUtpmedic.Models
{
    public class FarMed
    {
        public int      idmedicamento   { get; set; }
        public int      idfarmacia      { get; set; }
        public int      farmed_stock    { get; set; }
        public string   stock_unidad    { get; set; }
    }
}
