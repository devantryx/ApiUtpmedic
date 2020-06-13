using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ApiUtpmedic.Models
{
    public class Cita
    {
        [Key]
        public int idcita { get; set; }

        //relacion entre Cita y Paciente
        [ForeignKey("idpaciente")]
        public Paciente Paciente { get; set; }

        //relacion entre Cita y Horario
        [ForeignKey("idhorario")]
        public Horario Horario { get; set; }

    }
}
