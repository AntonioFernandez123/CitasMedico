using GestionCitasMedico.Dto;

namespace GestionCitasMedico.Service.interfaces
{
    public interface ICitaService
    {
        IEnumerable<CitaDTO> GetCita();
        CitaDTO GetCita(int id);
        Task<CitaDTO?> UpdateCita(int id, CitaDTO cita);
        Task<CitaDTO> CreateCita(CitaDTO cita);
        Task<bool> DeleteCita(int id);
    }
}
