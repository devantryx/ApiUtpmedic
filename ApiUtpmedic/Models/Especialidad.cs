using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApiUtpmedic.Models
{
    public class Especialidad
    {
        [Key]
        public int idespecialidad           { get; set; }
        public string especialidad_nombre   { get; set; }
    }
}
