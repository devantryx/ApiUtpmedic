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
    [Route("api/Medicos")]
    [ApiController]
    [ApiExplorerSettings(GroupName = "ApiMedicos")]
    public class MedicosController : ControllerBase
    {
        private readonly IMedicoRepository _ctRepo;
        private readonly IMapper _mapper;

        public MedicosController(IMedicoRepository ctRep, IMapper mapper)
        {
            _ctRepo = ctRep;//para q se pueda usar en toda la aplicaciòn
            _mapper = mapper;
        }

        /// <summary>
        /// Obtiene lista de medicos
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetMedicos()
        {
            var listaMedicos = _ctRepo.GetMedicos();
            var listaMedicosDto = new List<MedicoDto>();
            foreach (var lista in listaMedicos)
            {
                listaMedicosDto.Add(_mapper.Map<MedicoDto>(lista));
            }
            return Ok(listaMedicosDto);
        }

        /// <summary>
        /// Obtiene medico
        /// </summary>
        /// <param name="idmedico"></param>
        /// <returns></returns>
        [HttpGet("{idmedico:int}", Name = "GetMedico")]
        public IActionResult GetMedico(int idmedico)
        {
            var itemMedico = _ctRepo.GetMedico(idmedico);
            if (itemMedico == null)
            {
                return NotFound();
            }

            var itemMedicoDto = _mapper.Map<MedicoDto>(itemMedico);
            return Ok(itemMedicoDto);
        }

        /// <summary>
        /// Obtiene datos del medico
        /// </summary>
        /// <param name="idpaciente"></param>
        /// <returns></returns>
        [HttpGet("GetMedicodatos")]
        public IActionResult GetPersonaMedico()
        {
            try
            {

                var listaMedicoPer = _ctRepo.GetMedicoPersona();
                //var listaPacienteUsu = _ctRepo.GetMedicoUsuario();


                if (!listaMedicoPer.Any())
                {
                    return NotFound("No se encuentro registros");
                }

                var itemM = new List<MedicoDto>();

                foreach (var item in listaMedicoPer)
                {
                        itemM.Add(_mapper.Map<MedicoDto>(item));                   
                }
                return Ok(itemM);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error interno en el servidor.");
            }

        }


    }
}
