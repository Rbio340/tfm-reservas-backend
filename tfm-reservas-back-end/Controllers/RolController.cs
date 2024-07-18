using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Reserva.Core.Interfaces.Repository.MySql;
using Reserva.Core.Models;

namespace tfm_reservas_back_end.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class RolController : ControllerBase
    {
        private readonly IRolRepository _rolRepository;

        public RolController(IRolRepository rolRepository)
        {
            _rolRepository = rolRepository;
        }

        // GET: api/Rol
        [HttpGet]
        public ActionResult<IEnumerable<Rol>> GetRoles()
        {
            return Ok(_rolRepository.GetRoles());
        }

        // GET: api/Rol/5
        [HttpGet("{id}")]
        public ActionResult<Rol> GetRolById(int id)
        {
            var rol = _rolRepository.GetRolById(id);
            if (rol == null)
            {
                return NotFound();
            }

            return Ok(rol);
        }

        // POST: api/Rol
        [HttpPost]
        public ActionResult<Rol> CreateRol([FromBody] Rol rol)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _rolRepository.CreateRol(rol);

            return CreatedAtAction(nameof(GetRolById), new { id = rol.IdRol}, rol);
        }

        // PUT: api/Rol/5
        [HttpPut("{id}")]
        public IActionResult UpdateRol(int id, [FromBody] Rol rol)
        {
            if (id != rol.IdRol)
            {
                return BadRequest();
            }
            _rolRepository.UpdateRol(rol);

            return NoContent();
        }

        // DELETE: api/Rol/5
        [HttpDelete("{id}")]
        public IActionResult DeleteRol(int id)
        {
            var rol = _rolRepository.GetRolById(id);
            if (rol == null)
            {
                return NotFound();
            }

            rol.EstId= 0;

            _rolRepository.DeleteRol(rol);

            return NoContent();
        }
    }
}