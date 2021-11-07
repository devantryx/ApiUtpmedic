using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ApiUtpmedic.Models
{
    public class Paciente
    {
        [Key]
        public int idpaciente { get; set; }


        //relacion entre Paciente y Persona  
        
        public int idpersona { get; set; }
        [ForeignKey("idpersona")]
        public Persona Persona { get; set; }


        //Relacion entre Usuario y Paciente    
       
        public int idusuario { get; set; }
        [ForeignKey("idusuario")]
        public Usuario Usuario { get; set; }
    }
}
