using Microsoft.AspNetCore.Mvc;
using CursoApp.Api.Models;
using CursoApp.Shared;
using CursoApp.Shared.DataBaseModels;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CursoApp.Api.Controllers
{
    [ApiController] //-> Con esto no hace falta aclarar "[FromBody]" en los métodos.
    [Route("api/v1.0/[controller]/[action]")]

    public class EstadosController : Controller
    {


        private readonly IEntidadModelRepository<Estados> _estadoRepository;

        public EstadosController(IEntidadModelRepository<Estados> EstadoRepository)
        {
            _estadoRepository = EstadoRepository;
        }

        
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Estados))]
        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                return Ok(_estadoRepository.GetAllEntidadesModel());
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error al obtener los Estados. Contacte con el administrador.");
            }
        }

        [HttpGet("{xId}")]
        public IActionResult GetById(int xId)
        {
            try
            {
                return Ok(_estadoRepository.GetEntidadModelById(xId));
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error al obtener el Estado. Contacte con el administrador.");
            }
        }

    }
}
