using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

using static ApiUtpmedic.Models.Usuario;

namespace ApiUtpmedic.Models.Dtos
{
    //Ingreso de campos para crear usuario
    public class UsuarioCreateDto
    {
        [Required(ErrorMessage          =   "El usuario es requerido")]
        public string usuario_user          { get; set; }

        [Required(ErrorMessage          =   "La clave es requerido")]
        public string usuario_clave         { get; set; }

        [Required(ErrorMessage          =   "La clave2 es requerido")]
        public string usuario_clave2        { get; set; }

        public string nombrefoto            { get; set; }

        public IFormFile foto               { get; set; }

        [Required(ErrorMessage          =   "El id tipo usuario requerido son [1,2,3]")]
        public int idtipousuario    { get; set; }

        [Required(ErrorMessage          =   "Su dni es requerido")]
        public string    persona_dni        { get; set; }

        [Required(ErrorMessage          =   "Su Nombre es requerido")]
        public string persona_nombres       { get; set; }

        [Required(ErrorMessage              = "Sus Apellidos son requeridos")]
        public string persona_apellidos     { get; set; }

        [Required(ErrorMessage          =   "Su fecha de nacimiento es requerido")]
        public string fecNac                { get; set; }

        [Required(ErrorMessage              = "Su sexo es requerido")]
        public string persona_sexo          { get; set; }

        public string persona_direccion     { get; set; }
        public string persona_email         { get; set; }
        public string persona_telefono      { get; set; }
        public string persona_distrito      { get; set; }


        //public int idusuario                { get; set; }
        //public int idpersona                { get; set; }
        //public int idpaciente               { get; set; }
    }
}
