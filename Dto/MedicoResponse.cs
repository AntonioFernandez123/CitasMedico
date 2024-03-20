namespace GestionCitasMedico.Dto
{
    public class MedicoResponse : UsuarioDTO
    {
        public string numColegiado { get; set; }
        public ICollection<PacienteDTO> pacientes { get; set; }
    }
}
