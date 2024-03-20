using GestionCitasMedico.Models;

namespace GestionCitasMedico.Repository.interfaces
{
    public interface IUnitOfWork
    {
        ICitasMedicoRepository<Usuario> Usuarios { get; }
        MedicoRepository<Medico> Medicos { get; }
        PacienteRepository<Paciente> Pacientes { get; }
        CitaRepository<Cita> Citas { get; }
        ICitasMedicoRepository<Diagnostico> Diagnosticos { get; }
        Task<int> SaveChangesAsync();

    }
}
