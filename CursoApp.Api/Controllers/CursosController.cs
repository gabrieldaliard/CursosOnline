using CursoApp.Api.Models;
using CursoApp.Shared;
using CursoApp.Shared.DataBaseModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CursoApp.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class CursosController : Controller
    {
        private readonly IEntidadRepository<Cursos> _cursoRepository;

        public CursosController(IEntidadRepository<Cursos> CursoRepository)
        {
            _cursoRepository = CursoRepository;
        }

        [HttpGet]
        //[Route("Api/[controller]")] --> lo que sea que este antes de la palabara controller.
        public IActionResult GetAll(int cantFilasPagina = 0, int offSetPagina = 0, string orderBy = "")
        {
            try
            {
                return Ok(_cursoRepository.GetAllEntidades());
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error al obtener los cursos. Contacte con el administrador.");
            }
        }

        [HttpGet("{xId}")]
        public IActionResult GetById(int xId)
        {
            try
            {
                return Ok(_cursoRepository.GetEntidadById(xId));
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpDelete("{xId}")]
        public IActionResult DeleteById(int xId)
        {
            try
            {
                if (xId == 0)
                    return BadRequest();

                var cursoToDelete = _cursoRepository.GetEntidadById(xId);
                if (cursoToDelete == null)
                    return NotFound();

                _cursoRepository.DeleteEntidadById(xId);
                return NoContent();//success
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        public IActionResult Add([FromBody] Cursos curso)
        {
            try
            {
                if (curso == null)
                    return BadRequest();

                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var createdCurso = _cursoRepository.AddEntidad(curso);

                return Created("curso", createdCurso);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }


        [HttpPut]
        public IActionResult Update([FromBody] Cursos curso)
        {
            try
            {
                if (curso == null)
                    return BadRequest();

                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var cursoToUpdate = _cursoRepository.GetEntidadById(curso.idEntidad);

                if (cursoToUpdate == null)
                    return NotFound();

                _cursoRepository.UpdateEntidad(curso);

                return NoContent(); //success
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }

    }
}
