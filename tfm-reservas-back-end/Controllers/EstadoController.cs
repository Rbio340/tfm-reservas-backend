using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Reserva.Core.Interfaces.Repository.MySql;
using Reserva.Core.Models;

namespace tfm_reservas_back_end.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class EstadoController : ControllerBase
    {
        private readonly IEstadoRepository _estadoRepository;

        public EstadoController(IEstadoRepository estadoRepository)
        {
            _estadoRepository = estadoRepository;
        }

        // GET: api/Estado
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Estado>>> GetEstados()
        {
            if (_estadoRepository.EstadoExists == null)
            {
                return NotFound();
            }
            return _estadoRepository.GetEstado();
        }

        // GET: api/Estado/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Estado>> GetEstado(int id)
        {
            if (_estadoRepository.EstadoExists == null)
            {
                return NotFound();
            }
            var estado = _estadoRepository.GetEstadoById(id);

            if (estado == null)
            {
                return NotFound();
            }

            return estado;
        }

        // PUT: api/Estado/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEstado(int id, Estado estado)
        {
            if (id != estado.EstId)
            {
                return BadRequest();
            }

            try
            {
                _estadoRepository.UpdateEstado(estado);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_estadoRepository.EstadoExists(id))
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

        // POST: api/Estado
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Estado>> PostEstado(Estado estado)
        {
            if (_estadoRepository.EstadoExists == null)
            {
                return Problem("Entity set 'ReservaContext.Estados'  is null.");
            }
            _estadoRepository.CreateEstado(estado);

            return CreatedAtAction("GetEstado", new { id = estado.EstId }, estado);
        }

        // DELETE: api/Estado/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEstado(int id)
        {
            if (_estadoRepository.EstadoExists == null)
            {
                return NotFound();
            }
            var estado = _estadoRepository.GetEstadoById(id);
            if (estado == null)
            {
                return NotFound();
            }
            _estadoRepository.DeleteEstado(estado);

            return NoContent();
        }
    }
}