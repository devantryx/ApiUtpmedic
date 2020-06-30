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
    [Route("api/Medicamentos")]
    [ApiController]
    [ApiExplorerSettings(GroupName = "ApiMedicamentos")]
    public class MedicamentosController : ControllerBase
    {
        private readonly IMedicamentoRepository _clRepo;
        private readonly IMapper _mapper;

        public MedicamentosController(IMedicamentoRepository ctRep, IMapper mapper)
        {
            _clRepo = ctRep;//para q se pueda usar en toda la aplicaciòn
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetMedicamentos()//Obtiene lista de todos los medicamentos
        {
            var listaMedicamentos = _clRepo.GetMedicamentos();
            var listaMedicamentosDto = new List<MedicamentoDto>();
            foreach (var lista in listaMedicamentos)
            {
                listaMedicamentosDto.Add(_mapper.Map<MedicamentoDto>(lista));
            }
            return Ok(listaMedicamentosDto);
        }

        [HttpGet("{idmedicamento:int}", Name = "GetMedicamento")]
        public IActionResult GetMedicamento(int idmedicamento)
        {
            var itemMedicamento = _clRepo.GetMedicamento(idmedicamento);
            if (itemMedicamento == null)
            {
                return NotFound();
            }

            var itemMedicamentoDto = _mapper.Map<MedicamentoDto>(itemMedicamento);
            return Ok(itemMedicamentoDto);
        }

        [HttpGet("buscarmedicamento")]
        public IActionResult BuscarMedicamento(string nombre)
        {
            try
            {
                var resultado = _clRepo.BuscarMedicamento(nombre);
                if (resultado.Any())
                {
                    return Ok(resultado);
                }
                return NotFound("No se encuentro el medicamento ingresado");

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error interno en el servidor.");
            }
        }

    }
}
