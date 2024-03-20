using GestionCitasMedico.Dto;
using GestionCitasMedico.Models;
using GestionCitasMedico.Service;
using GestionCitasMedico.Service.interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GestionCitasMedico.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicoController : ControllerBase
    {
        private readonly IMedicoService _medicoService;

        public MedicoController(IMedicoService medicoService)
        {
            _medicoService = medicoService;
        }

        // GET: api/Medico
        [HttpGet]
        public ActionResult<IEnumerable<MedicoResponse>> GetMedico()
        {
            return Ok(_medicoService.GetMedico());
        }

        // GET: api/Medico/5
        [HttpGet("{id}")]
        public ActionResult<MedicoResponse> GetMedico(int id)
        {
            var medico = _medicoService.GetMedico(id);
            if (medico == null)
            {
                return NotFound();
            }
            return medico;
        }

        // PUT: api/Medico/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMedico(int id, MedicoDTO medico)
        {
            var updatedMedico = await _medicoService.UpdateMedico(id, medico);
            if (updatedMedico == null)
            {
                return BadRequest();
            }
            return NoContent();
        }

        // POST: api/Medico
        [HttpPost]
        public async Task<ActionResult<MedicoDTO>> PostMedico(MedicoDTO medico)
        {
            var createdMedico = await _medicoService.CreateMedico(medico);
            return CreatedAtAction("GetMedico", new { id = createdMedico.Id }, createdMedico);
        }

        // DELETE: api/Medico/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMedico(int id)
        {
            var success = await _medicoService.DeleteMedico(id);
            if (!success)
            {
                return NotFound();
            }
            return NoContent();
        }
    }

}
