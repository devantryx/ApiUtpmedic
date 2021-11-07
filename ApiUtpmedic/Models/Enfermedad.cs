using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApiUtpmedic.Models
{
    public class Enfermedad
    {
        [Key]
        public int      idenfermedad        { get; set; }
        public string   enfermedad_nombre   { get; set; }
        public string   enfermedad_tipo     { get; set; }

    }
}
