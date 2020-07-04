using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiUtpmedic.Models.Dtos;
using ApiUtpmedic.Repository.IRepository;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiUtpmedic.Controllers
{
    [Route("api/Pacientes")]
    [ApiController]
    [ApiExplorerSettings(GroupName = "ApiPacientes")]
    public class PacientesController : ControllerBase
    {
        private readonly IPacienteRepository _ctRepo;
        private readonly IMapper _mapper;

        public PacientesController(IPacienteRepository ctRep, IMapper mapper)
        {
            _ctRepo = ctRep;//para q se pueda usar en toda la aplicaciòn
            _mapper = mapper;
        }


        /// <summary>
        /// Obtiene datos del paciente
        /// </summary>
        /// <param name="idpaciente"></param>
        /// <returns></returns>
        [HttpGet("GetPacientedatos")]
        public IActionResult GetPersonaPaciente()
        {
            try
            {

                var listaPacientePer = _ctRepo.GetPacientePersona();
               
                if (!listaPacientePer.Any())
                {
                    return NotFound("No se encuentro registros");
                }

                var itemP = new List<PacientePersonaDto>();

                foreach (var item in listaPacientePer)
                {
                        itemP.Add(_mapper.Map<PacientePersonaDto>(item));                   
                }
                return Ok(itemP);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error interno en el servidor.");
            }

        }


        /// <summary>
        /// Obtiene datos id paciente y usuario
        /// </summary>
        /// <param name="idpaciente"></param>
        /// <returns></returns>
        [HttpGet("GetPacienteusuario")]
        public IActionResult GetUsuarioPaciente()
        {
            try
            {

                var listaPacienteUsu = _ctRepo.GetPacienteUsuario();


                if (!listaPacienteUsu.Any())
                {
                    return NotFound("No se encuentro registros");
                }

                var itemP = new List<PacienteUsuarioDto>();

                foreach (var item in listaPacienteUsu)
                {
                    itemP.Add(_mapper.Map<PacienteUsuarioDto>(item));
                }
                return Ok(itemP);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error interno en el servidor.");
            }

        }

    }
}
