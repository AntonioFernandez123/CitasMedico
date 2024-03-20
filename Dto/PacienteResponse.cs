using GestionCitasMedico.Models;

namespace GestionCitasMedico.Dto
{
    public class PacienteResponse : UsuarioDTO
    {
        public string NSS { get; set; }
        public string numTarjeta { get; set; }
        public string telefono { get; set; }
        public string direccion { get; set; }
        public ICollection<MedicoDTO> medicos { get; set; }
    }
}
