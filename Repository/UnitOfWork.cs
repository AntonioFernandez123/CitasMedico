using GestionCitasMedico.Data;
using GestionCitasMedico.Models;
using GestionCitasMedico.Repository.interfaces;

namespace GestionCitasMedico.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext _context;

        public UnitOfWork(DataContext context)
        {
            _context = context;
            Usuarios = new CitasMedicoRepository<Usuario>(_context);
            Medicos = new MedicoRepository<Medico>(_context);
            Pacientes = new PacienteRepository<Paciente>(_context);
            Citas = new CitaRepository<Cita>(_context);
            Diagnosticos = new CitasMedicoRepository<Diagnostico>(_context);

        }
        public ICitasMedicoRepository<Usuario> Usuarios { get; }
        public MedicoRepository<Medico> Medicos { get; }
        public PacienteRepository<Paciente> Pacientes { get; }
        public CitaRepository<Cita> Citas { get; }
        public ICitasMedicoRepository<Diagnostico> Diagnosticos { get; }

        public async Task<int> SaveChangesAsync() => await _context.SaveChangesAsync();
    }
}
