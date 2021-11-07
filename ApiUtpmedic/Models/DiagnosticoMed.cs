using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiUtpmedic.Models
{
    public class DiagnosticoMed
    {
        public int idmedicamento                    { get; set; }
        public int iddiagnostico                    { get; set; }
        public string diagnosticomed_unidad         { get; set; }
        public string diagnosticomed_cantidad       { get; set; }
        public string diagnosticomed_frecuencia     { get; set; }
    }
}
