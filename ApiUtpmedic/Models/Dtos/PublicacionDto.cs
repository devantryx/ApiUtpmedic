using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApiUtpmedic.Models.Dtos
{
    public class PublicacionDto
    {
        public int      id                      { get; set; }
        
        [Required(ErrorMessage = "El nombre es obligatorio")]
        public string   mensaje                 { get; set; }
        
        public int      megusta                 { get; set; }
        public int      idusuario               { get; set; }
        public string   usuario_user            { get; set; }
        public string   nombrefoto              { get; set; }
        public string   fecha_publicacion       { get; set; }

    }
}
