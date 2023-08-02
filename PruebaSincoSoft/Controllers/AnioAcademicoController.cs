using Logic.AnioAcademicoLogic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace PruebaSincoSoft.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnioAcademicoController : ControllerBase
    {
        private readonly IAnioAcademicoLogic _anioAcademicoLogic;

        public AnioAcademicoController(IAnioAcademicoLogic anioAcademicoLogic)
        {
            this._anioAcademicoLogic = anioAcademicoLogic;
        }

        /// <summary>
        /// Accion que permite listar los años academicos.
        /// </summary>
        /// <returns>Lista de años academicos.</returns>
        [HttpGet()]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll()
        {
            var result = await _anioAcademicoLogic.GetAllAsync();
            return Ok(result);
        }
    }
}
