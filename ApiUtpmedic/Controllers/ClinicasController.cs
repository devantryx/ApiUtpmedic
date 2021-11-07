using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiUtpmedic.Models;
using ApiUtpmedic.Models.Dtos;
using ApiUtpmedic.Repository.IRepository;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiUtpmedic.Controllers
{
    [Route("api/Clinicas")]
    [ApiController]
    [ApiExplorerSettings(GroupName = "ApiUtpmedicClinicas")]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]//Codigo de espuesta para la clase en caso que no encuentre la ruta
    public class ClinicasController : Controller
    {
        private readonly IClinicaRepository _clRepo;
        private readonly IMapper _mapper;

        public ClinicasController(IClinicaRepository ctRep, IMapper mapper)
        {
            _clRepo = ctRep;//para q se pueda usar en toda la aplicaciòn
            _mapper = mapper;
        }

        /// <summary>
        /// Obtiene clinicas
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetClinicas()
        {
            var listaClinicas = _clRepo.GetClinicas();
            var listaClinicasDto = new List<ClinicaDto>();
            foreach (var lista in listaClinicas)
            {
                listaClinicasDto.Add(_mapper.Map<ClinicaDto>(lista));
            }
            return Ok(listaClinicasDto);
        }

        /// <summary>
        /// Obtiene clinica por Id
        /// </summary>
        /// <param name="idclinica"></param>
        /// <returns></returns>
        [HttpGet("{idclinica:int}", Name = "GetClinica")]
        public IActionResult GetClinica(int idclinica)
        {
            var itemClinica = _clRepo.GetClinica(idclinica);
            if (itemClinica == null)
            {
                return NotFound();
            }

            var itemClinicaDto = _mapper.Map<EspecialidadDto>(itemClinica);
            return Ok(itemClinicaDto);
        }

        /// <summary>
        /// Crea nueva cita
        /// </summary>
        /// <param name="clinicaDto"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult CrearClinica([FromBody] ClinicaDto clinicaDto)
        {
            if (clinicaDto == null)
            {
                return BadRequest(ModelState);
            }
            if (_clRepo.ExisteClinica(clinicaDto.clinica_nombre))
            {
                ModelState.AddModelError("", "La clinica ya existe");
                return StatusCode(404, ModelState);
            }

            var clinica = _mapper.Map<Clinica>(clinicaDto);

            if (!_clRepo.CrearClinica(clinica))
            {
                ModelState.AddModelError("", $"Algo salio mal, guardando el registro{clinica.clinica_nombre}");
                return StatusCode(500, ModelState);
            }

            return CreatedAtRoute("GetClinica", new { idclinica = clinica.idclinica }, clinica);
        }

        /// <summary>
        /// Actualiza clinica por Id
        /// </summary>
        /// <param name="idclinica"></param>
        /// <param name="clinicaDto"></param>
        /// <returns></returns>
        [HttpPatch("{idclinica:int}", Name = "ActualizarClinica")]
        public IActionResult ActualizarClinica(int idclinica, [FromBody] ClinicaDto clinicaDto)
        {
            if (clinicaDto == null || idclinica != clinicaDto.idclinica)
            {
                return BadRequest(ModelState);
            }
            var clinica = _mapper.Map<Clinica>(clinicaDto);

            if (!_clRepo.ActualizarClinica(clinica))
            {
                ModelState.AddModelError("", $"Algo salio mal, actualizando el registro{clinica.clinica_nombre}");
                return StatusCode(500, ModelState);
            }

            return NoContent();

        }

        /// <summary>
        /// Borra clinica por Id
        /// </summary>
        /// <param name="idclinica"></param>
        /// <returns></returns>
        [HttpDelete("{idclinica:int}", Name = "BorrarClinica")]
        public IActionResult BorrarClinica(int idclinica)
        {

            if (!_clRepo.ExisteClinica(idclinica))
            {
                return NotFound();
            }

            var clinica = _clRepo.GetClinica(idclinica);
            if (!_clRepo.BorrarClinica(clinica))
            {
                ModelState.AddModelError("", $"Algo salio mal, borrando el registro{clinica.clinica_nombre}");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }

    }
}
