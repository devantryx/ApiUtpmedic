using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ApiUtpmedic.Models
{
    public class Horario
    {
        [Key]
        public int idhorario            { get; set; }
        public string horario_hinicio   { get; set; }
        public string horario_hfin      {get;set;}
        public string horario_dia       { get; set; }

        //relacion entre Horario y Medico
        [ForeignKey("idmedico")]
        public Medico Medico            { get; set; }
        
    }
}
