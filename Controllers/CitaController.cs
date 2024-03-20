using GestionCitasMedico.Dto;
using GestionCitasMedico.Models;
using GestionCitasMedico.Service;
using GestionCitasMedico.Service.interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GestionCitasMedico.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CitaController : ControllerBase
    {
        private readonly ICitaService _citaService;

        public CitaController(ICitaService citaService)
        {
            _citaService = citaService;
        }

        // GET: api/Cita
        [HttpGet]
        public ActionResult<IEnumerable<CitaDTO>> GetCita()
        {
            return Ok(_citaService .GetCita());
        }

        // GET: api/Cita/5
        [HttpGet("{id}")]
        public ActionResult<CitaDTO> GetCita(int id)
        {
            var medico = _citaService.GetCita(id);
            if (medico == null)
            {
                return NotFound();
            }
            return medico;
        }

        // PUT: api/Cita/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCita(int id, CitaDTO cita)
        {
            var updatedCita = await _citaService.UpdateCita(id, cita);
            if (updatedCita == null)
            {
                return BadRequest();
            }
            return NoContent();
        }

        // POST: api/Cita
        [HttpPost]
        public async Task<ActionResult<CitaDTO>> PostCita(CitaDTO cita)
        {
            var createdCita = await _citaService.CreateCita(cita);
            return CreatedAtAction("GetCita", new { id = createdCita.Id }, createdCita);
        }

        // DELETE: api/Cita/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCita(int id)
        {
            var success = await _citaService.DeleteCita(id);
            if (!success)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
