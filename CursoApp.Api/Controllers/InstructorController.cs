using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CursoApp.Shared.DataBaseModels;
using Microsoft.AspNetCore.Mvc;
using CursoApp.Api.Models;

namespace CursoApp.Api.Controllers
{
    [ApiController]
    public class InstructorController : Controller
    {
        private readonly IInstructorRepository _instructorRepository;

        public InstructorController(IInstructorRepository InstructorRepository)
        {
            _instructorRepository = InstructorRepository;
        }

        //[HttpGet]
        //[Route("Api/GetAllCursos")]
        ////[Route("Api/[controller]")] --> lo que sea que este antes de la palabara controller.
        //public IActionResult GetAllCursos(int cantFilasPagina = 0, int offSetPagina = 0, string orderBy = "")
        //{
        //    try
        //    {
        //        return Ok(_cursoRepository.GetAllCursos());
        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(500, "Internal server error");
        //    }
        //}

        //[HttpGet]
        //[Route("api/GetCursoById/{xCursoId}")]
        //public IActionResult GetCursoById(int xCursoId)
        //{
        //    try
        //    {
        //        return Ok(_cursoRepository.GetCursoById(xCursoId));
        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(500, "Internal server error");
        //    }
        //}

        //[HttpDelete]
        //[Route("api/DeleteCursoById/{xCursoId}")]
        //public IActionResult DeleteCursoById(int xCursoId)
        //{
        //    try
        //    {
        //        if (xCursoId == 0)
        //            return BadRequest();

        //        var cursoToDelete = _cursoRepository.GetCursoById(xCursoId);
        //        if (cursoToDelete == null)
        //            return NotFound();

        //        _cursoRepository.DeleteCursoById(xCursoId);
        //        return NoContent();//success
        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(500, "Internal server error");
        //    }
        //}

        //[HttpPost]
        //[Route("api/AddCurso")]
        ////[Route("AddCurso")]
        //public IActionResult AddCurso([FromBody] Cursos curso)
        //{
        //    try
        //    {
        //        if (curso == null)
        //            return BadRequest();

        //        if (!ModelState.IsValid)
        //            return BadRequest(ModelState);

        //        var createdCurso = _cursoRepository.AddCurso(curso);

        //        return Created("curso", createdCurso);
        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(500, "Internal server error");
        //    }
        //}


        //[HttpPut]
        //[Route("api/UpdateCurso")]
        ////[Route("UpdateCurso")]
        //public IActionResult UpdateCurso([FromBody] Cursos curso)
        //{
        //    try
        //    {
        //        if (curso == null)
        //            return BadRequest();

        //        if (!ModelState.IsValid)
        //            return BadRequest(ModelState);

        //        var cursoToUpdate = _cursoRepository.GetCursoById(curso.IdCurso);

        //        if (cursoToUpdate == null)
        //            return NotFound();

        //        _cursoRepository.UpdateCurso(curso);

        //        return NoContent(); //success
        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(500, "Internal server error");
        //    }
        //}
    }
}
