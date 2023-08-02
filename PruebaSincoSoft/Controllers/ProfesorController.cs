using Logic.ProfesorLogic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaSincoSoft.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfesorController : ControllerBase
    {
        private readonly IProfesorLogic _profesorLogic;

        public ProfesorController(IProfesorLogic profesorLogic)
        {
            this._profesorLogic = profesorLogic;
        }

        /// <summary>
        /// Accion que permite hacer la creacion de un nuevo profesor.
        /// </summary>
        /// <param name="profesorModel">Informacion del nuevo profesor.</param>
        /// <returns>Nuevo profesor agregado.</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ProfesorModel))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Add([FromBody] ProfesorModel profesorModel)
        {
            // Se realiza la validacion del modelo.
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(await _profesorLogic.AddAsync(profesorModel));
        }

        /// <summary>
        /// Accion que permite hacer la actualizacion de un profesor.
        /// </summary>
        /// <param name="profesorModel">Informacion actualizada del profesor .</param>
        /// <param name="id">Identificador del profesor a modificar.</param>
        /// <returns>Profesor actualizado.</returns>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ProfesorModel))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Update(int id, [FromBody] ProfesorModel profesorModel)
        {
            // Se realiza la validacion del modelo.
            if (!ModelState.IsValid || id <= 0)
            {
                return BadRequest(ModelState);
            }

            var result = await _profesorLogic.UpdateAsync(id, profesorModel);

            if (result != null)
            {
                return Ok();
            }
            return NotFound(new { Message = "El profesor no esta registrado en la base de datos!" });
        }

        /// <summary>
        /// Accion que permite la eliminacion de un profesor.
        /// </summary>
        /// <param name="id">Identificador del profesor a eliminar.</param>
        /// <returns>Profesor eliminado.</returns>
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

            var result = await _profesorLogic.RemoveAsync(id);

            if (result != null)
            {
                return Ok();
            }
            return NotFound(new { Message = "El profesor no esta registrado en la base de datos!" });
        }

        /// <summary>
        /// Accion que permite listar los profesores.
        /// </summary>
        /// <returns>Lista de profesores.</returns>
        [HttpGet()]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll()
        {
            var result = await _profesorLogic.GetAllAsync();
            return Ok(result);
        }

        /// <summary>
        /// Accion que permite listar un profesor por Id.
        /// <param name="id">Identificador del profesor.</param>
        /// </summary>
        /// <returns>Un profesor.</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> Get(int id)
        {
            var result = await _profesorLogic.FindAsync(id);
            if (result == null)
                return NotFound(new { Message = "El profesor no esta registrado en la base de datos!" });

            return Ok(result);
        }

    }
}
