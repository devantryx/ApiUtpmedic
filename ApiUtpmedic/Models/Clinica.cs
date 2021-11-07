using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApiUtpmedic.Models
{
    public class Clinica
    {
        [Key]
        public int      idclinica           { get; set; }
        public string   clinica_nombre      { get; set; }
        public string   clinica_direccion   { get; set; }
        public string   clinica_telefono    { get; set; }
        public string   clinica_email       { get; set; }
        public string   clinica_ruc         { get; set; }
        public string   clinica_distrito    { get; set; }

    }
}
