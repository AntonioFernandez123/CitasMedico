namespace GestionCitasMedico.Dto
{
    public class CitaDTO
    {
        public int Id { get; set; }
        public DateTime fechaHora { get; set; }
        public string motivoCita { get; set; }
        public int idMedico {  get; set; }
        public int idPaciente { get; set; }
        public DiagnosticoDTO Diagnostico { get; set; }
    }
}

