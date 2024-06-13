using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Reserva.Core.Interfaces.Repository.MySql;
using Reserva.Core.Models;

namespace tfm_reservas_back_end.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CatalogoAreaComunController : ControllerBase
    {
        private readonly ICatalogoAreaComunRepository _areaComunRepository;

        public CatalogoAreaComunController(ICatalogoAreaComunRepository areaComunRepository)
        {
            _areaComunRepository= areaComunRepository;
        }

        // GET: api/CatalogoAreaComun
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CatalogoAreaComun>>> GetCatalogoAreaComuns()
        {
          if (_areaComunRepository.CatalogoAreaComunExists== null)
          {
              return NotFound();
          }
            return _areaComunRepository.GetCatalogoAreaComun();
        }

        // GET: api/CatalogoAreaComun/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CatalogoAreaComun>> GetCatalogoAreaComun(int id)
        {
          if (_areaComunRepository.CatalogoAreaComunExists == null)
          {
              return NotFound();
          }
            var catalogoAreaComun = _areaComunRepository.GetCatalogoAreaComunById(id);

            if (catalogoAreaComun == null)
            {
                return NotFound();
            }

            return catalogoAreaComun;
        }

        // PUT: api/CatalogoAreaComun/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCatalogoAreaComun(int id, CatalogoAreaComun catalogoAreaComun)
        {
            if (id != catalogoAreaComun.CatespId)
            {
                return BadRequest();
            }

            try
            {
                _areaComunRepository.UpdateCatalogoAreaComun(catalogoAreaComun);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_areaComunRepository.CatalogoAreaComunExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/CatalogoAreaComun
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CatalogoAreaComun>> PostCatalogoAreaComun(CatalogoAreaComun catalogoAreaComun)
        {
          if (_areaComunRepository.CatalogoAreaComunExists == null)
          {
              return Problem("Entity set 'ReservaContext.CatalogoAreaComuns'  is null.");
          }
            _areaComunRepository.CreateCatalogoAreaComun(catalogoAreaComun);

            return CreatedAtAction("GetCatalogoAreaComun", new { id = catalogoAreaComun.CatespId }, catalogoAreaComun);
        }

        // DELETE: api/CatalogoAreaComun/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCatalogoAreaComun(int id)
        {
            if (_areaComunRepository.CatalogoAreaComunExists == null)
            {
                return NotFound();
            }
            var catalogoAreaComun = _areaComunRepository.GetCatalogoAreaComunById(id);
            if (catalogoAreaComun == null)
            {
                return NotFound();
            }
            catalogoAreaComun.EstId = 0;
            _areaComunRepository.DeleteCatalogoAreaComun(catalogoAreaComun);
            return NoContent();
        }
    }
}
