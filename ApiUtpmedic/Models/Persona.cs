using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApiUtpmedic.Models
{
    public class Persona
    {
        [Key]
        public int      idpersona           { get; set; }
        public string   persona_dni         { get; set; }
        public string   persona_nombres     { get; set; }
        public string   persona_apellidos   { get; set; }
        public string   fecNac              { get; set; }
        public string   persona_sexo        { get; set; }
        public string   persona_direccion   { get; set; }
        public string   persona_email       { get; set; }
        public string   persona_telefono    { get; set; }
        public string   persona_distrito    { get; set; }
        
     
    }
}
