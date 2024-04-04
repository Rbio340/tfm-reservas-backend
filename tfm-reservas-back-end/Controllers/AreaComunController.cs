using Microsoft.AspNetCore.Mvc;
using Reserva.Core.Interfaces.Repository.MySql;
using Reserva.Core.Models;

namespace tfm_reservas_back_end.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AreaComunController : ControllerBase
    {
        private readonly IAreaComunRepository _areaComunRepository;
        private readonly ICatalogoAreaComunRepository _catalogoAreaComun;
        private readonly IEstadoRepository _estadoRepository;

        public AreaComunController(IAreaComunRepository areaComun,
            ICatalogoAreaComunRepository catalogoAreaComun, IEstadoRepository estado)
        {
            _areaComunRepository = areaComun;
            _catalogoAreaComun = catalogoAreaComun;
            _estadoRepository = estado;
        }

        // GET: api/AreaComun
        [HttpGet]
        public ActionResult<IEnumerable<AreaComun>> GetAreasComun()
        {
            return Ok(_areaComunRepository.GetAreasComun());
        }

        // GET: api/AreaComun/5
        [HttpGet("{id}")]
        public ActionResult<AreaComun> GetAreaComunById(int id)
        {
            var areaComun = _areaComunRepository.GetAreaComunById(id);
            if (areaComun == null)
            {
                return NotFound();
            }

            return Ok(areaComun);
        }

        // POST: api/AreaComun
        [HttpPost]
        public ActionResult<AreaComun> CreateAreaComun([FromBody] AreaComun areaComun)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _areaComunRepository.CreateAreaComun(areaComun);

            return CreatedAtAction(nameof(GetAreaComunById), new { id = areaComun.EspId }, areaComun);
        }

        // PUT: api/AreaComun/5
        [HttpPut("{id}")]
        public IActionResult UpdateAreaComun(int id, [FromBody] AreaComun areaComun)
        {
            if (id != areaComun.EspId)
            {
                return BadRequest();
            }

            _areaComunRepository.UpdateAreaComun(areaComun);

            return NoContent();
        }

        // DELETE: api/AreaComun/5
        [HttpDelete("{id}")]
        public IActionResult DeleteAreaComun(int id)
        {
            var areaComun = _areaComunRepository.GetAreaComunById(id);
            if (areaComun == null)
            {
                return NotFound();
            }

            _areaComunRepository.DeleteAreaComun(areaComun);

            return NoContent();
        }
    }
}
