using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ApiUtpmedic.Models
{
    public class Usuario

    {      
        [Key]
        public int          idusuario       { get; set; }       
        public string       usuario_user    { get; set; }
        public byte[]       usuario_clave   { get; set; }
        public byte[]       usuario_clave2  { get; set; }       
        public string       nombrefoto      { get; set; }              
        //public enum         tipousuario     { Opciones,Administrador, Medico, Paciente } //0, 1 , 2, 3
        public int          idtipousuario   { get; set; }

        //Relacion entre Usuario y TipoUsuario    
        [ForeignKey("idtipousuario")]
        public TipoUsuario TipoUsuario { get; set; }


    }
}
