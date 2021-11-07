using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ApiUtpmedic.Models
{
    public class Diagnostico
    {
        [Key]
        public int iddiagnostico            { get; set; }
        public string diagnostico_sintomas  { get; set; }

        //relacion entre Diagnostico y Cita
        [ForeignKey("idcita")]
        public Cita Cita                    { get; set; }

        //relacion entre Diagnostico y Historial
        [ForeignKey("idpaciente")]
        public Historial Historial          { get; set; }
    }
}
