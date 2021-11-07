using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ApiUtpmedic.Models
{
    public class Medico
    {
        [Key]
        public int idmedico                 { get; set; }

        //relacion entre Medico y Especialidad
        [ForeignKey("idespecialidad")]
        public Especialidad Especialidad    { get; set; }

        //relacion entre Medico y Clicina
        [ForeignKey("idclinica")]
        public Clinica Clinica              { get; set; }

        //relacion entre Medico y Persona
        [ForeignKey("idpersona")]
        public Persona Persona              { get; set; }

    }
}
