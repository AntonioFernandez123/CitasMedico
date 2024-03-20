using GestionCitasMedico.Data;
using GestionCitasMedico.Models;
using Microsoft.EntityFrameworkCore;

namespace GestionCitasMedico.Repository
{
    public class CitaRepository<T> : CitasMedicoRepository<T> where T : class
    {
        private readonly DataContext _context;

        public CitaRepository(DataContext context) : base(context) 
        { 
            _context = context;
        }

        public new async Task<IEnumerable<Cita>> GetAllAsync()
        {
            return await _context.Cita.Include(d => d.Diagnostico).ToListAsync();
        }

        public new async Task<Cita> GetByIdAsync(int id)
        {
            return await _context.Cita.Include(d => d.Diagnostico).FirstAsync(d => d.Id == id);
        }
    }
}
 
