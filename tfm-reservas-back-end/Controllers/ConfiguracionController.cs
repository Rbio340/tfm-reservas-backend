using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Reserva.Core.Interfaces.Repository.MySql;
using Reserva.Core.Models;

namespace tfm_reservas_back_end.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class ConfiguracionController : ControllerBase
    {
        private readonly IConfiguracionRepository _configuracionRepository;
        public ConfiguracionController(IConfiguracionRepository configuracionRepository)
        {
            _configuracionRepository = configuracionRepository;
        }

        // GET: Configuracion
        [HttpGet]
        public ActionResult<IEnumerable<Configuracion>> GetConfiguracion()
        {
            return Ok(_configuracionRepository.GetConfiguracion());
        }

        // GET: api/Configuracion/5
        [HttpGet("{id}")]
        public ActionResult<Configuracion> GetConfiguracionById(int id)
        {
            var configuracion = _configuracionRepository.GetConfiguracionById(id);
            if (configuracion == null || configuracion.ConfigId == 0) 
            {
                return new JsonResult(new { }); 
            }

            return Ok(configuracion);
        }

        // POST: api/Configuracion
        [HttpPost]
        public ActionResult<Configuracion> CreateConfiguracion([FromBody] Configuracion configuracion)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _configuracionRepository.CreateConfiguracion(configuracion);

            return CreatedAtAction(nameof(GetConfiguracionById), new { id = configuracion.ConfigId }, configuracion);
        }

        // PUT: api/Configuracion/5
        [HttpPut("{id}")]
        public IActionResult UpdateConfiguracion (int id, [FromBody] Configuracion configuracion)
        {
            if (id != configuracion.ConfigId)
            {
                return BadRequest();
            }

            _configuracionRepository.UpdateConfiguracion(configuracion);

            return NoContent();
        }

        // DELETE: api/Configuracion/5
        [HttpDelete("{id}")]
        public IActionResult DeleteConfiguracion(int id)
        {
            var configuracion = _configuracionRepository.GetConfiguracionById(id);
            if (configuracion == null)
            {
                return NotFound();
            }

            _configuracionRepository.DeleteConfiguracion(configuracion);

            return NoContent();
        }
    }
}