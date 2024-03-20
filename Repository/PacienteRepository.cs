using GestionCitasMedico.Data;
using GestionCitasMedico.Models;
using Microsoft.EntityFrameworkCore;

namespace GestionCitasMedico.Repository
{
    public class PacienteRepository<T> : CitasMedicoRepository<T> where T : class
    {
        private readonly DataContext _context;

        public PacienteRepository(DataContext context) : base(context)
        {
            _context = context;
        }

        public new async Task<IEnumerable<Paciente>> GetAllAsync()
        {
            return await _context.Paciente.Include(m => m.Medicos).ToListAsync();
        }

        public new async Task<Paciente> GetByIdAsync(int id)
        {
            return await _context.Paciente.Include(m => m.Medicos).FirstAsync(d => d.Id == id);
        }
    }
}
