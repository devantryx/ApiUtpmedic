using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ApiUtpmedic.Models
{
    public class Publicacion
    {
        [Key]
        public int      id                  { get; set; }
        public string   mensaje             { get; set; }
        public int      megusta             { get; set; }       
        public string   usuario_user        { get; set; }
        public string   nombrefoto          { get; set; }
        public string   fecha_publicacion    { get; set; }


        //relacion entre Publicacion y Usuario
        [ForeignKey("idusuario")]
        public Usuario Usuario              { get; set; }

    }
}
