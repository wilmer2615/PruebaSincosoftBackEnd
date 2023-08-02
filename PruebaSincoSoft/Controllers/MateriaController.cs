using Logic.MateriaLogic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using System.Threading.Tasks;

namespace PruebaSincoSoft.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MateriaController : ControllerBase
    {
        private readonly IMateriaLogic _materiaLogic;
        public MateriaController(IMateriaLogic materiaLogic)
        {
            this._materiaLogic = materiaLogic;
        }

        /// <summary>
        /// Accion que permite hacer la creacion de una nueva materia.
        /// </summary>
        /// <param name="materiaModel">Informacion de la nueva materia.</param>
        /// <returns>Nueva materia agregada.</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(MateriaModel))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Add([FromBody] MateriaModel materiaModel)
        {
            // Se realiza la validacion del modelo.
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(await _materiaLogic.AddAsync(materiaModel));
        }
        

        /// <summary>
        /// Accion que permite la eliminacion de una materia.
        /// </summary>
        /// <param name="id">Identificador de la materia a eliminar.</param>
        /// <returns>Materia eliminada.</returns>
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

            var result = await _materiaLogic.RemoveAsync(id);

            if (result != null)
            {
                return Ok();
            }
            return NotFound(new { Message = "La materia no esta registrada en la base de datos!" });
        }

        /// <summary>
        /// Accion que permite listar las materias.
        /// </summary>
        /// <returns>Lista de materias.</returns>
        [HttpGet()]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll()
        {
            var result = await _materiaLogic.GetAllAsync();
            return Ok(result);
        }

        
    }
}
