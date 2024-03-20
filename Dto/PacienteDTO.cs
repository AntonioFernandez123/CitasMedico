namespace GestionCitasMedico.Dto
{
    public class PacienteDTO : UsuarioDTO
    {
        public string NSS { get; set; }
        public string numTarjeta { get; set; }
        public string telefono { get; set; }
        public string direccion { get; set; }
    }
}
