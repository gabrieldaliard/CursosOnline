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
    //[Route("Api/[controller]")] --> lo que sea que este antes de la palabara controller.
    public class CursosController : Controller
    {
        private readonly IEntidadRepository<Cursos> _cursoRepository;

        public CursosController(IEntidadRepository<Cursos> CursoRepository)
        {
            _cursoRepository = CursoRepository;
        }

        [HttpGet]
        [Route("Api/GetAllCursos")]
        //[Route("Api/[controller]")] --> lo que sea que este antes de la palabara controller.
        public IActionResult GetAllCursos(int cantFilasPagina = 0, int offSetPagina = 0, string orderBy = "")
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

        [HttpGet]
        [Route("api/GetCursoById/{xCursoId}")]
        public IActionResult GetCursoById(int xCursoId)
        {
            try
            {
                return Ok(_cursoRepository.GetEntidadById(xCursoId));
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpDelete]
        [Route("api/DeleteCursoById/{xCursoId}")]
        public IActionResult DeleteCursoById(int xCursoId)
        {
            try
            {
                if (xCursoId == 0)
                    return BadRequest();

                var cursoToDelete = _cursoRepository.GetEntidadById(xCursoId);
                if (cursoToDelete == null)
                    return NotFound();

                _cursoRepository.DeleteEntidadById(xCursoId);
                return NoContent();//success
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        [Route("api/AddCurso")]
        //[Route("AddCurso")]
        public IActionResult AddCurso([FromBody] Cursos curso)
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
        [Route("api/UpdateCurso")]
        //[Route("UpdateCurso")]
        public IActionResult UpdateCurso([FromBody] Cursos curso)
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
