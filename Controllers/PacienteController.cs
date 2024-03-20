using GestionCitasMedico.Dto;
using GestionCitasMedico.Models;
using GestionCitasMedico.Service;
using GestionCitasMedico.Service.interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GestionCitasMedico.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PacienteController : ControllerBase
    {
        private readonly IPacienteService _pacienteService;
        public PacienteController(IPacienteService pacienteService)
        {
            _pacienteService = pacienteService;
        }

        // GET: api/Paciente
        [HttpGet]
        public ActionResult<IEnumerable<PacienteResponse>> GetPaciente()
        {
            return Ok(_pacienteService.GetPaciente());
        }

        // GET: api/Paciente/5
        [HttpGet("{id}")]
        public ActionResult<PacienteResponse> GetPaciente(int id)
        {
            var paciente = _pacienteService.GetPaciente(id);
            if (paciente == null)
            {
                return NotFound();
            }
            return paciente;
        }

        // PUT: api/Paciente/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPaciente(int id, PacienteDTO paciente)
        {
            var updatedPaciente = await _pacienteService.UpdatePaciente(id, paciente);
            if (updatedPaciente == null)
            {
                return BadRequest();
            }
            return NoContent();
        }

        // POST: api/Paciente
        [HttpPost]
        public async Task<ActionResult<PacienteDTO>> PostPaciente(PacienteDTO paciente)
        {
            var createdPaciente = await _pacienteService.CreatePaciente(paciente);
            return CreatedAtAction("GetPaciente", new { id = createdPaciente.Id }, createdPaciente);
        }

        // DELETE: api/Paciente/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePaciente(int id)
        {
            var success = await _pacienteService.DeletePaciente(id);
            if (!success)
            {
                return NotFound();
            }
            return NoContent();
        }
    } 
}
