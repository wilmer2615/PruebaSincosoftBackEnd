using Logic.CalificacionLogic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using System.Threading.Tasks;

namespace PruebaSincoSoft.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalificacionController : ControllerBase
    {
        private readonly ICalificacionLogic _calificacionLogic;

        public CalificacionController(ICalificacionLogic calificacionLogic)
        {
            this._calificacionLogic = calificacionLogic;
        }


        /// <summary>
        /// Accion que permite hacer la creacion de una nueva calificacion.
        /// </summary>
        /// <param name="calificacionModel">Informacion de la nueva calificacion.</param>
        /// <returns>Nueva calificacion agregada.</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Add([FromBody] CalificacionModel calificacionModel)
        {
            // Se realiza la validacion del modelo.
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _calificacionLogic.AddAsync(calificacionModel);

            if (result != null)
            {
                return Ok();
            }
            return NotFound(new { Message = "El alumno ya tiene registrada esa materia en ese año academico!" });

        }        

        /// <summary>
        /// Accion que permite la eliminacion de una calificacion.
        /// </summary>
        /// <param name="id">Identificador de la calificacion a eliminar.</param>
        /// <returns>Calificacion eliminada.</returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Remove(int id)
        {
            // Se realiza la validacion.
            if (id <= 0)
            {
                return BadRequest(ModelState);
            }

            var result = await _calificacionLogic.RemoveAsync(id);

            if (result != null)
            {
                return Ok();
            }
            return NotFound(new { Message = "La calificacion no esta registrada en la base de datos!" });
        }

        /// <summary>
        /// Accion que permite listar las calificaciones.
        /// </summary>
        /// <returns>Lista de calificaciones.</returns>
        [HttpGet()]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll()
        {
            var result = await _calificacionLogic.GetAllAsync();
            return Ok(result);
        }

        
    }
}
