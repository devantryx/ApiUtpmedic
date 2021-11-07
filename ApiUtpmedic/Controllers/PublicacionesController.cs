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
    [Route("api/Publicaciones")]
    [ApiController]
    [ApiExplorerSettings(GroupName = "ApiUtpmedicPublicaciones")]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]//Codigo de espuesta para la clase en caso que no encuentre la ruta
    public class PublicacionesController : Controller
    {
        private readonly IPublicacionRepository _pcRepo;
        private readonly IMapper _mapper;

        public PublicacionesController(IPublicacionRepository ctRep, IMapper mapper)
        {
            _pcRepo = ctRep;//para q se pueda usar en toda la aplicaciòn
            _mapper = mapper;
        }

        /// <summary>
        /// Obtener las publicaciones
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetPublicaciones()
        {
            var listaPublicaciones = _pcRepo.GetPublicaciones();
            var listaPublicacionesDto = new List<PublicacionDto>();
            foreach (var lista in listaPublicaciones)
            {
                listaPublicacionesDto.Add(_mapper.Map<PublicacionDto>(lista));
            }
            return Ok(listaPublicacionesDto);
        }

        /// <summary>
        /// Buscar publicaciones por Id
        /// </summary>
        /// <param name="publicacionId"></param>
        /// <returns></returns>
        [HttpGet("{publicacionId:int}", Name = "GetPublicacion")]
        public IActionResult GetPublicacion(int publicacionId)
        {
            var itemPublicacion = _pcRepo.GetPublicaciones(publicacionId);
            if (itemPublicacion == null)
            {
                return NotFound();
            }

            var itemPublicacionDto = _mapper.Map<PublicacionDto>(itemPublicacion);
            return Ok(itemPublicacionDto);
        }

        /// <summary>
        /// Crea nueva publicaciòn
        /// </summary>
        /// <param name="publicacionDto"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult CrearPublicacion([FromBody] PublicacionDto publicacionDto)
        {
            if (publicacionDto == null)
            {
                return BadRequest(ModelState);
            }


            var publicacion = _mapper.Map<Publicacion>(publicacionDto);

            if (!_pcRepo.CrearPublicacion(publicacion))
            {
                ModelState.AddModelError("", $"Algo salio mal, guardando el registro{publicacion.id}");
                return StatusCode(500, ModelState);
            }

            return CreatedAtRoute("GetPublicacion", new { publicacionId = publicacion.id }, publicacion); //resultado:muestra en el body 
        }

        /// <summary>
        /// Actualiza publicaciòn
        /// </summary>
        /// <param name="publicacionId"></param>
        /// <param name="publicacionDto"></param>
        /// <returns></returns>
        [HttpPatch("{publicacionId:int}", Name = "ActualizarPublicacion")]
        public IActionResult ActualizarPublicacion(int publicacionId, [FromBody] PublicacionDto publicacionDto)
        {
            if (publicacionDto == null || publicacionId != publicacionDto.id)
            {
                return BadRequest(ModelState);
            }
            var publicacion = _mapper.Map<Publicacion>(publicacionDto);

            if (!_pcRepo.ActualizarPublicacion(publicacion))
            {
                ModelState.AddModelError("", $"Algo salio mal, actualizando el registro{publicacion.id}");
                return StatusCode(500, ModelState);
            }

            return NoContent();

        }

        /// <summary>
        /// Borra publicaciòn por Id
        /// </summary>
        /// <param name="publicacionId"></param>
        /// <returns></returns>
        [HttpDelete("{publicacionId:int}", Name = "BorrarPublicacion")]
        public IActionResult BorrarPublicacion(int publicacionId)
        {

            if (!_pcRepo.ExistePublicacion(publicacionId))
            {
                return NotFound();
            }

            var publicacion = _pcRepo.GetPublicaciones(publicacionId);
            if (!_pcRepo.BorrarPublicacion(publicacion))
            {
                ModelState.AddModelError("", $"Algo salio mal, borrando el registro{publicacion.id}");
                return StatusCode(500, ModelState);
            }

            return NoContent();

        }
      
    }
}
