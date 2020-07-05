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
    [Route("api/Horarios")]
    [ApiController]
    [ApiExplorerSettings(GroupName = "ApiHorariosMedico")]
    public class HorariosController : Controller
    {
        private readonly IHorarioRepository _ctRepo;
        private readonly IMapper _mapper;

        public HorariosController(IHorarioRepository ctRep, IMapper mapper)
        {
            _ctRepo = ctRep;//para q se pueda usar en toda la aplicaciòn
            _mapper = mapper;
        }

        /// <summary>
        /// Obtiene horarios
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetHorariosMedico")]
        public IActionResult GetHorariosMedico()
        {
            var listaHorarios = _ctRepo.GetHorariosMedico();
            var listaHorariosDto = new List<HorarioDto>();
            foreach (var lista in listaHorarios)
            {
                listaHorariosDto.Add(_mapper.Map<HorarioDto>(lista));
            }
            return Ok(listaHorariosDto);
        }

        /// <summary>
        /// Obtiene horario por Id
        /// </summary>
        /// <param name="idhorario"></param>
        /// <returns></returns>
        [HttpGet("{idhorario:int}", Name = "GetHorarioMedico")]
        public IActionResult GetHorarioMedico(int idhorario)
        {
            var itemHorario = _ctRepo.GetHorarioMedico(idhorario);
            if (itemHorario == null)
            {
                return NotFound();
            }

            var itemHorarioDto = _mapper.Map<HorarioDto>(itemHorario);
            return Ok(itemHorarioDto);
        }

    }
}
