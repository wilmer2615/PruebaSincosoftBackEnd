using Logic.AlumnoLogic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using System.Threading.Tasks;

namespace PruebaSincoSoft.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlumnoController : ControllerBase
    {
        private readonly IAlumnoLogic _alumnoLogic;

        public AlumnoController(IAlumnoLogic alumnoLogic)
        {
            this._alumnoLogic = alumnoLogic;
        }

        /// <summary>
        /// Accion que permite hacer la creacion de un nuevo alumno.
        /// </summary>
        /// <param name="alumnoModel">Informacion del nuevo alumno.</param>
        /// <returns>Nuevo alumno agregado.</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AlumnoModel))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Add([FromBody] AlumnoModel alumnoModel)
        {
            // Se realiza la validacion del modelo.
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(await _alumnoLogic.AddAsync(alumnoModel));
        }

        /// <summary>
        /// Accion que permite hacer la actualizacion de un alumno.
        /// </summary>
        /// <param name="alumnoModel">Informacion actualizada del alumno .</param>
        /// <param name="id">Identificador del alumno a modificar.</param>
        /// <returns>Alumno actualizado.</returns>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AlumnoModel))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Update(int id, [FromBody] AlumnoModel alumnoModel)
        {
            // Se realiza la validacion del modelo.
            if (!ModelState.IsValid || id <= 0)
            {
                return BadRequest(ModelState);
            }

            var result = await _alumnoLogic.UpdateAsync(id, alumnoModel);

            if (result != null)
            {
                return Ok();
            }
            return NotFound(new { Message = "El alumno no esta registrado en la base de datos!" });
        }

        /// <summary>
        /// Accion que permite la eliminacion de un alumno.
        /// </summary>
        /// <param name="id">Identificador del alumno a eliminar.</param>
        /// <returns>Alumno eliminado.</returns>
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

            var result = await _alumnoLogic.RemoveAsync(id);

            if (result != null)
            {
                return Ok();
            }
            return NotFound(new { Message = "El alumno tiene materias asignadas o no esta registrado en la base de datos!" });
        }

        /// <summary>
        /// Accion que permite listar los alumnos.
        /// </summary>
        /// <returns>Lista alumnos.</returns>
        [HttpGet()]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll()
        {
            var result = await _alumnoLogic.GetAllAsync();
            return Ok(result);
        }

        /// <summary>
        /// Accion que permite listar un alumno por Id.
        /// <param name="id">Identificador del alumno.</param>
        /// </summary>
        /// <returns>Un alumno.</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> Get(int id)
        {
            var result = await _alumnoLogic.FindAsync(id);
            if (result == null)
                return NotFound(new { Message = "El alumno no esta registrado en la base de datos!"});

            return Ok(result);
        }
    }
}
