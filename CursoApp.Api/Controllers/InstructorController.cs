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
    [Route("api/v1.0/[controller]/[action]")]
    public class InstructorController : Controller
    {
        private readonly IEntidadModelRepository<Instructores> _instructorRepository;

        public InstructorController(IEntidadModelRepository<Instructores> InstructorRepository)
        {
            _instructorRepository = InstructorRepository;
        }

        [HttpGet]     
        public IActionResult GetAll(int cantFilasPagina = 0, int offSetPagina = 0, string orderBy = "")
        {
            try
            {
                return Ok(_instructorRepository.GetAllEntidadesModel());
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
                return Ok(_instructorRepository.GetEntidadModelById(xId));
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

                var instructorToDelete = _instructorRepository.GetEntidadModelById(xId);
                if (instructorToDelete == null)
                    return NotFound();

                _instructorRepository.DeleteEntidadModelById(xId);
                return NoContent();//success
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        public IActionResult Add([FromBody] Instructores xInstructor)
        {
            try
            {
                if (xInstructor == null)
                    return BadRequest();

                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var createdInstructor = _instructorRepository.AddEntidadModel(xInstructor);

                return Created("curso", createdInstructor);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }


        [HttpPut]
        public IActionResult Update([FromBody] Instructores xInstructor)
        {
            try
            {
                if (xInstructor == null)
                    return BadRequest();

                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var instructorToUpdate = _instructorRepository.GetEntidadModelById(xInstructor.idEntidad);

                if (instructorToUpdate == null)
                    return NotFound();

                _instructorRepository.UpdateEntidadModel(xInstructor, xInstructor.idEntidad);

                return NoContent(); //success
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }


    }
}
