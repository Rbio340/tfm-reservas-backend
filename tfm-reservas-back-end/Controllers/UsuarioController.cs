﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Reserva.Core.Interfaces.Repository.MySql;
using Reserva.Core.Models;

namespace tfm_reservas_back_end.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepository _usuario;

        public UsuarioController(IUsuarioRepository usuarioRepository)
        {
            _usuario = usuarioRepository;
        }

        // GET: api/Usuario
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Usuario>>> GetUsuarios()
        {
            if (_usuario.UsuarioExists == null)
            {
                return NotFound();
            }
            return _usuario.GetUsuarios();
        }

        // GET: api/Usuario/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Usuario>> GetUsuario(int id)
        {
            if (_usuario.UsuarioExists == null)
            {
                return NotFound();
            }
            var usuario = _usuario.GetUsuarioById(id);

            if (usuario == null)
            {
                return NotFound();
            }
            return usuario;
        }

        // PUT: api/Usuario/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUsuario(int id, Usuario usuario)
        {
            if (id != usuario.UsuId)
            {
                return BadRequest();
            }

            try
            {
                _usuario.UpdateUsuario(usuario);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_usuario.UsuarioExists(id))
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

        // POST: api/Usuario
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Usuario>> PostUsuario(Usuario usuario)
        {
            if (_usuario.UsuarioExists == null)
            {
                return Problem("Entity set 'ReservaContext.Usuarios'  is null.");
            }
            _usuario.CreateUsuario(usuario);

            return CreatedAtAction("GetUsuario", new { id = usuario.UsuId }, usuario);
        }

        // DELETE: api/Usuario/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUsuario(int id)
        {
            if (_usuario.UsuarioExists == null)
            {
                return NotFound();
            }
            var usuario = _usuario.GetUsuarioById(id);
            if (usuario == null)
            {
                return NotFound();
            }
            usuario.EstId = usuario.EstId == 1 ? 0 : 1;
            _usuario.DeleteUsuario(usuario);
            return NoContent();
        }

        [HttpGet("existsByCedula/{cedula}")]
        public async Task<ActionResult<bool>> ExistsByCedula(string cedula)
        {
            if (_usuario.UsuarioExists == null)
            {
                return NotFound();
            }
            bool exists = _usuario.UsuarioExistsByCedula(cedula);
            return Ok(new { ok = exists });
        }

        [HttpGet("existsByNombreUsuario/{nombreUsuario}")]
        public async Task<ActionResult<bool>> ExistsByNombreUsuario(string nombreUsuario)
        {
            if (_usuario.UsuarioExists == null)
            {
                return NotFound();
            }
            bool exists = _usuario.UsuarioExistsByNombreUsuario(nombreUsuario);
            return Ok(new { ok = exists } );
        }
    }
}