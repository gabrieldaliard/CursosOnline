using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CursoApp.Api.Models;
using CursoApp.Shared.DataBaseModels;

namespace UsuarioApp.Api.Controllers
{

    [ApiController] //-> Con esto no hace falta aclarar "[FromBody]" en los métodos.
    [Route("api/v1.0/[controller]/[action]")]
    
    public class UsuariosController : Controller
    {
        private readonly IEntidadModelRepository<Usuarios> _UsuarioRepository;

        public UsuariosController(IEntidadModelRepository<Usuarios> UsuarioRepository)
        {
            _UsuarioRepository = UsuarioRepository;
        }


        /// <summary>
        /// Obtiene todos Usuarios disponibles.
        /// </summary>
        /// <param name="cantFilasPagina"> Cantidad de filas PAPAAAA</param>
        /// <param name="offSetPagina"></param>
        /// <param name="orderBy"></param>
        /// <returns>IActionResult</returns>
        /// <remarks>
        /// Ejemplo de Request \
        /// </remarks>
        [HttpGet]
        //[ApiVersion("2.0")]
        //[ApiVersion("1.0")]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Usuarios))]
        public IActionResult GetAll(int cantFilasPagina = 0, int offSetPagina = 0, string orderBy = "")
        {
            try
            {
                return Ok(_UsuarioRepository.GetAllEntidadesModel());
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error al obtener los Usuarios. Contacte con el administrador.");
            }
        }

        [HttpGet("{xId}")]
        public IActionResult GetById(int xId)
        {
            try
            {
                return Ok(_UsuarioRepository.GetEntidadModelById(xId));
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

                var UsuarioToDelete = _UsuarioRepository.GetEntidadModelById(xId);
                if (UsuarioToDelete == null)
                    return NotFound();

                _UsuarioRepository.DeleteEntidadModelById(xId);
                return Ok();//success
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        public IActionResult Add([FromBody] Usuarios Usuario)
        {
            try
            {
                if (Usuario == null)
                    return NotFound();
                
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var createdUsuario = _UsuarioRepository.AddEntidadModel(Usuario);

                return Created("Usuario", createdUsuario);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
            
        }


        [HttpPut]
        public IActionResult Update([FromBody] Usuarios Usuario)
        {
            try
            {
                if (Usuario == null)
                    return BadRequest();

                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var UsuarioToUpdate = _UsuarioRepository.GetEntidadModelById(Usuario.idEntidad);

                if (UsuarioToUpdate == null)
                    return NotFound();

                _UsuarioRepository.UpdateEntidadModel(Usuario, Usuario.idEntidad);

                return NoContent(); //success
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }

    }
}
