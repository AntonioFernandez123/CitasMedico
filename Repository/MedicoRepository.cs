using GestionCitasMedico.Data;
using GestionCitasMedico.Models;
using Microsoft.EntityFrameworkCore;

namespace GestionCitasMedico.Repository
{
    public class MedicoRepository<T> : CitasMedicoRepository<T> where T : class
    {
        private readonly DataContext _context;

        public MedicoRepository(DataContext context) : base(context)
        {
            _context = context;
        }
        public new async Task<IEnumerable<Medico>> GetAllAsync()
        {
            return await _context.Medico.Include(p => p.Pacientes).ToListAsync();
        }

        public new async Task<Medico> GetByIdAsync(int id)
        {
            return await _context.Medico.Include(p => p.Pacientes).FirstAsync(d => d.Id == id);
        }
    }
}
