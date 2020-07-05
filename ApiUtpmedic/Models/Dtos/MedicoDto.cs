using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiUtpmedic.Models.Dtos
{
    public class MedicoDto
    {
        public int idmedico { get; set; }
      //  public int idespecialidad { get; set; }
       // public int idclinica { get; set; }
        public string foto_url { get; set; }
        public int experiencia { get; set; }

        public Persona Persona { get; set; }

        public Especialidad Especialidad { get; set; }


    }
}
