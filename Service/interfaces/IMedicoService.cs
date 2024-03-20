using GestionCitasMedico.Dto;
using GestionCitasMedico.Models;

namespace GestionCitasMedico.Service.interfaces
{
    public interface IMedicoService
    {
        IEnumerable<MedicoResponse> GetMedico();
        MedicoResponse GetMedico(int id);
        Task<MedicoDTO?> UpdateMedico(int id, MedicoDTO medico);
        Task<MedicoDTO> CreateMedico(MedicoDTO medico);
        Task<bool> DeleteMedico(int id);
    }  

}
