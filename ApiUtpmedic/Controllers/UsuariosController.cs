using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using ApiUtpmedic.Models;
using ApiUtpmedic.Models.Dtos;
using ApiUtpmedic.Repository.IRepository;
using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace ApiUtpmedic.Controllers
{
    [Route("api/Usuarios")]
    [ApiController]
    [ApiExplorerSettings(GroupName = "ApiUtpmedicUsuarios")]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]//Codigo de espuesta para la clase en caso que no encuentre la ruta
    public class UsuariosController : Controller
    {
        private readonly IUsuarioRepository _userRepo;
        private readonly IWebHostEnvironment _hostEnvironment;
        private readonly IMapper _mapper;
        private readonly IConfiguration _config;

        public UsuariosController(IUsuarioRepository userRep, IMapper mapper, IWebHostEnvironment hostEnvironment, IConfiguration config)//
        {
            _userRepo = userRep;//para q se pueda usar en toda la aplicaciòn
            _mapper = mapper;           
            _hostEnvironment = hostEnvironment;
            _config = config;

        }

        /// <summary>
        /// Crea un nuevo usuario
        /// </summary>
        /// <param name="UsuarioDto"></param>
        /// <returns></returns>
        [HttpPost]       
        [ProducesResponseType(201, Type = typeof(List<UsuarioDto>))]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesDefaultResponseType]
        public IActionResult CrearUsuario([FromForm] UsuarioCreateDto UsuarioDto)//,UsuarioAuthDto usuarioAuthDto
        {
            try
            {
                if (UsuarioDto == null)
                {
                    return BadRequest(ModelState);
                }

                UsuarioDto.usuario_user = UsuarioDto.usuario_user.ToLower();
                if (_userRepo.ExisteUsuario(UsuarioDto.usuario_user))
                {
                    return StatusCode(404, "El usuario ingresado ya existe");
                    //ModelState.AddModelError("", "El usuario ingreado ya existe");
                    //return StatusCode(404, ModelState);
                }
                var archivo = UsuarioDto.foto;
                string ruta = _hostEnvironment.WebRootPath;
                var archivos = HttpContext.Request.Form.Files;

                if (archivo.Length > 0)
                {
                    var nombreFoto = Guid.NewGuid().ToString();
                    //var subida = Path.Combine(ruta, @"fotos");
                    var subida = Path.Combine(ruta, @"fotos/ImageDefault");
                    var extension = Path.GetExtension(archivos[0].FileName);

                    //using (var fileStreams = new FileStream(Path.Combine(subida, nombreFoto + //extension), FileMode.Create))
                    using (var fileStreams = new FileStream(Path.Combine(subida + extension), FileMode.Create))
                    {
                        archivos[0].CopyTo(fileStreams);
                    }
                    UsuarioDto.nombrefoto = nombreFoto + extension;
                }

                var personaCrear = new Persona
                {
                    persona_dni = UsuarioDto.persona_dni,
                    persona_nombres = UsuarioDto.persona_nombres,
                    persona_apellidos = UsuarioDto.persona_apellidos,
                    fecNac = UsuarioDto.fecNac,
                    persona_sexo = UsuarioDto.persona_sexo,
                    persona_direccion = UsuarioDto.persona_direccion,
                    persona_email = UsuarioDto.persona_email,
                    persona_telefono = UsuarioDto.persona_telefono,
                    persona_distrito = UsuarioDto.persona_distrito

                };

                var usuarioCrear = new Usuario
                {
                    usuario_user = UsuarioDto.usuario_user,
                    nombrefoto = UsuarioDto.nombrefoto,
                    idtipousuario = UsuarioDto.idtipousuario
                };

                var pacienteCrear = new Paciente
                {

                };

                var usuarioCreado = _userRepo.CrearUsuario(personaCrear, usuarioCrear, pacienteCrear, UsuarioDto.usuario_clave);
                //return Ok(usuarioCreado);
               // var result = _mapper.Map<Usuario>(UsuarioDto);
                return CreatedAtRoute("GetUsuario", new { usuarioId = usuarioCreado.idusuario }, usuarioCreado); //resultado:muestra en el body 


            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error interno en el servidor.");
            }            
        }

        /// <summary>
        /// Inicia sesión
        /// </summary>
        /// <param name="usuarioAuthLoginDto"></param>
        /// <returns></returns>
        [HttpPost("Login")]
        public IActionResult Login(UsuarioAuthLoginDto usuarioAuthLoginDto)
        {

            var usuarioDesdeRepo = _userRepo.Login(usuarioAuthLoginDto.usuario, usuarioAuthLoginDto.clave);

            if (usuarioDesdeRepo == null)
            {
                return Unauthorized("Usuario no autorizado");
            }

            //genera claim
            var claims = new[]
            {
                new Claim("Id", usuarioDesdeRepo.idusuario.ToString()),
                new Claim("Usuario", usuarioDesdeRepo.usuario_user.ToString())

            };

            //genera el token
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.GetSection("AppSettings:Token").Value));
            var credenciales = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Issuer = "www.utpmedic.com",
                Audience = "www.utpmedic.com",
                Expires = DateTime.Now.AddMonths(1),
                SigningCredentials = credenciales

            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return Ok(new
            {
                token = tokenHandler.WriteToken(token),
                id = usuarioDesdeRepo.idusuario.ToString(),
                usuario = usuarioDesdeRepo.usuario_user.ToString(),
                namefoto = usuarioDesdeRepo.nombrefoto.ToString(),
                idtipousuario = usuarioDesdeRepo.idtipousuario.ToString()
            });

        }


        /// <summary>
        /// Lista todos los usuario
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(List<UsuarioDto>))]
        [ProducesResponseType(400)]
        public IActionResult GetUsuarios()
        {
            var listaUsuarios = _userRepo.GetUsuarios();
            var listaUsuarioDto = new List<UsuarioDto>();

            if (!listaUsuarios.Any())
            {
                return NotFound("No hay usuarios registrados");
            }

            foreach (var lista in listaUsuarios)
            {
                listaUsuarioDto.Add(_mapper.Map<UsuarioDto>(lista));
            }
            return Ok(listaUsuarioDto);
        }

        /// <summary>
        /// Obtiene un usuario existente
        /// </summary>
        /// <param name="usuarioId">Usuario id</param>
        /// <returns></returns>
        [HttpGet("{usuarioId:int}", Name = "GetUsuario")]
        [ProducesResponseType(200, Type = typeof(List<UsuarioDto>))]
        [ProducesResponseType(404)]
        [ProducesDefaultResponseType]
        public IActionResult GetUsuario(int usuarioId)
        {
            var itemUsuario = _userRepo.GetUsuario(usuarioId);
            if (itemUsuario == null)
            {
                return NotFound();
            }

            var itemUsuarioDto = _mapper.Map<UsuarioDto>(itemUsuario);
            return Ok(itemUsuarioDto);
        }


        /// <summary>
        /// Obtener datos del usuario
        /// </summary>
        /// <param name="dni">DNI del usuario</param>
        /// <returns></returns>
        [HttpGet("buscarpordni")]
        public IActionResult BuscarUsuarioPersona(string dni)
        {
            try
            {
                var resultado = _userRepo.TraerDatosUsuario(dni);
                if (resultado.Any()) {
                    return Ok(resultado);    
                }
                return NotFound("No se encuentro el usuario");

            }catch(Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error interno en el servidor.");
            }
        }

        /// <summary>
        /// Obtiene datos del paciente
        /// </summary>
        /// <param name="idpaciente">Id del paciente</param>
        /// <returns></returns>
        [HttpGet("GetPacientedatos/{idpaciente:int}")]
        public IActionResult GetPersonaUsuario(int idpaciente)
        {
            try {

                var listaPacientePer = _userRepo.GetPacientePersona(idpaciente);
                var listaPacienteUsu = _userRepo.GetPacienteUsuario(idpaciente);

                if (!listaPacientePer.Any() || !listaPacienteUsu.Any())
                {
                    return NotFound("No se encuentro registros");
                }

                var itemPer = new List<PacienteDto>();

                foreach (var item in listaPacientePer)
                {
                    foreach (var item2 in listaPacienteUsu)
                    {
                        itemPer.Add(_mapper.Map<PacienteDto>(item));
                    }
                }
                return Ok(itemPer);
            }
            catch (Exception) {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error interno en el servidor.");
            }
          
        }

        
    }
}
