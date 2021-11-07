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
    [Route("api/Especialidades")]
    [ApiController]
    [ApiExplorerSettings(GroupName = "ApiUtpmedicEspecialidades")]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]//Codigo de espuesta para la clase en caso que no encuentre la ruta
    public class EspecialidadesController : Controller
    {
        private readonly IEspecialidadRepository _ctRepo;
        private readonly IMapper _mapper;

        public EspecialidadesController(IEspecialidadRepository ctRep, IMapper mapper)
        {
            _ctRepo = ctRep;//para q se pueda usar en toda la aplicaciòn
            _mapper = mapper;
        }

        /// <summary>
        /// Obtiene especialidades
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetEspecialidades()
        {
            var listaEspecialidades = _ctRepo.GetEspecialidades();
            var listaEspecialidadesDto = new List<EspecialidadDto>();
            foreach (var lista in listaEspecialidades)
            {
                listaEspecialidadesDto.Add(_mapper.Map<EspecialidadDto>(lista));
            }
            return Ok(listaEspecialidadesDto);
        }

        /// <summary>
        /// Obtiene especialidades por Id
        /// </summary>
        /// <param name="especialidadId"></param>
        /// <returns></returns>
        [HttpGet("{especialidadId:int}", Name = "GetEspecialidad")]
        public IActionResult GetEspecialidad(int especialidadId)
        {
            var itemEspecialidad = _ctRepo.GetEspecialidad(especialidadId);
            if (itemEspecialidad == null)
            {
                return NotFound();
            }

            var itemEspecialidadDto = _mapper.Map<EspecialidadDto>(itemEspecialidad);
            return Ok(itemEspecialidadDto);
        }

        /// <summary>
        /// Crea nueva especialidad
        /// </summary>
        /// <param name="especialidadDto"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult CrearEspecialidad([FromBody] EspecialidadDto especialidadDto)
        {
            if (especialidadDto == null)
            {
                return BadRequest(ModelState);
            }
            if (_ctRepo.ExisteEspecialidad(especialidadDto.especialidad_nombre))
            {
                ModelState.AddModelError("", "La especialidad ya existe");
                return StatusCode(404, ModelState);
            }

            var especialidad = _mapper.Map<Especialidad>(especialidadDto);

            if (!_ctRepo.CrearEspecialidad(especialidad))
            {
                ModelState.AddModelError("", $"Algo salio mal, guardando el registro{especialidad.especialidad_nombre}");
                return StatusCode(500, ModelState);
            }

            return CreatedAtRoute("GetEspecialidad", new { especialidadId = especialidad.idespecialidad }, especialidad);
        }

        /// <summary>
        /// Actualiza especialidad por Id
        /// </summary>
        /// <param name="especialidadId"></param>
        /// <param name="especialidadDto"></param>
        /// <returns></returns>
        [HttpPatch("{especialidadId:int}", Name = "ActualizarEspecialidad")]
        public IActionResult ActualizarEspecialidad(int especialidadId, [FromBody] EspecialidadDto especialidadDto)
        {
            if (especialidadDto == null || especialidadId != especialidadDto.idespecialidad)
            {
                return BadRequest(ModelState);
            }
            var especialidad = _mapper.Map<Especialidad>(especialidadDto);

            if (!_ctRepo.ActualizarEspecialidad(especialidad))
            {
                ModelState.AddModelError("", $"Algo salio mal, actualizando el registro{especialidad.especialidad_nombre}");
                return StatusCode(500, ModelState);
            }

            return NoContent();

        }

        /// <summary>
        /// Borra especialidad por Id
        /// </summary>
        /// <param name="especialidadId"></param>
        /// <returns></returns>
        [HttpDelete("{especialidadId:int}", Name = "BorrarEspecialidad")]
        public IActionResult BorrarEspecialidad(int especialidadId)
        {

            if (!_ctRepo.ExisteEspecialidad(especialidadId))
            {
                return NotFound();
            }

            var especialidad = _ctRepo.GetEspecialidad(especialidadId);
            if (!_ctRepo.BorrarEspecialidad(especialidad))
            {
                ModelState.AddModelError("", $"Algo salio mal, borrando el registro{especialidad.especialidad_nombre}");
                return StatusCode(500, ModelState);
            }

            return NoContent();

        }
    }
}
