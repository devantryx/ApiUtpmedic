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
    [Route("api/Citas")]
    [ApiController]
    [ApiExplorerSettings(GroupName = "ApiUtpmedicCitas")]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]//Codigo de espuesta para la clase en caso que no encuentre la ruta
    public class CitasController : Controller
    {
        private readonly ICitaRepository _ctRepo;
        private readonly IMapper _mapper;

        public CitasController(ICitaRepository ctRep, IMapper mapper)
        {
            _ctRepo = ctRep;//para q se pueda usar en toda la aplicaciòn
            _mapper = mapper;
        }

        /// <summary>
        /// Obtiene citas
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetCitas()
        {
            var listaCitas = _ctRepo.GetCitas();
            var listaCitasDto = new List<CitaDto>();
            foreach (var lista in listaCitas)
            {
                listaCitasDto.Add(_mapper.Map<CitaDto>(lista));
            }
            return Ok(listaCitasDto);
        }

        /// <summary>
        /// Obtiene cita por Id
        /// </summary>
        /// <param name="idcita"></param>
        /// <returns></returns>
        [HttpGet("{idcita:int}", Name = "GetCita")]
        public IActionResult GetCita(int idcita)
        {
            var itemCita= _ctRepo.GetCita(idcita);
            if (itemCita == null)
            {
                return NotFound();
            }

            var itemCitaDto = _mapper.Map<CitaDto>(itemCita);
            return Ok(itemCitaDto);
        }

    }
}
