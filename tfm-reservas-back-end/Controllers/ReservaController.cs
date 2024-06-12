using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Reserva.Core.Interfaces.Repository.MySql;
using Reserva.Core.Models;
using Reserva.Repository.Context;

namespace tfm_reservas_back_end.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservaController : ControllerBase
    {
        private readonly IReservaRepository _reservaRepository;

        public ReservaController(IReservaRepository reservaRepository)
        {
            _reservaRepository = reservaRepository;
        }

        // GET: api/Reserva
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Reservas>>> GetReservas()
        {
            if (_reservaRepository.ReservaExists == null)
            {
                return NotFound();
            }
            return _reservaRepository.GetReserva();
        }

        // GET: api/Reserva/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Reservas>> GetReservas(int id)
        {
            var reservas = _reservaRepository.GetReservaById(id);

            if (reservas == null || reservas.ResId == 0)
            {
                return new JsonResult(new { });
            }

            return reservas;
        }

        // PUT: api/Reserva/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutReservas(int id, Reservas reservas)
        {
            if (id != reservas.ResId)
            {
                return BadRequest();
            }

            try
            {
                _reservaRepository.UpdateReserva(reservas);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_reservaRepository.ReservaExists(id))
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

        // POST: api/Reserva
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Reservas>> PostReservas(Reservas reservas)
        {
            if (_reservaRepository.ReservaExists == null)
            {
                return Problem("Entity set 'ReservaContext.Reservas'  is null.");
            }
            _reservaRepository.CreateReserva(reservas);

            return CreatedAtAction("GetReservas", new { id = reservas.ResId }, reservas);
        }

        // DELETE: api/Reserva/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReservas(int id)
        {
            if (_reservaRepository.ReservaExists == null)
            {
                return NotFound();
            }
            var reservas = _reservaRepository.GetReservaById(id);
            if (reservas == null)
            {
                return NotFound();
            }

            reservas.EstId = 0;

            _reservaRepository.DeleteReserva(reservas);

            return NoContent();
        }
    }
}
