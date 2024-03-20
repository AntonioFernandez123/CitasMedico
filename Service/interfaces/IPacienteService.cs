using GestionCitasMedico.Dto;
using GestionCitasMedico.Models;

namespace GestionCitasMedico.Service.interfaces
{
    public interface IPacienteService
    {
        IEnumerable<PacienteResponse> GetPaciente();
        PacienteResponse GetPaciente(int id);
        Task<PacienteDTO?> UpdatePaciente(int id, PacienteDTO paciente);
        Task<PacienteDTO> CreatePaciente(PacienteDTO paciente);
        Task<bool> DeletePaciente(int id);
    }
}
