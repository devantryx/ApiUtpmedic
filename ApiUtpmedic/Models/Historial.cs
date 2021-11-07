using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ApiUtpmedic.Models
{
    public class Historial
    {
        [Key]
        public int idhistorial          { get; set; }
        public string historial_codigo  { get; set; }
        public string historial_fecha   { get; set; }

        //relacion entre Historial y Paciente
        [ForeignKey("idpaciente")]
        public Paciente Paciente        { get; set; }
    }
}
