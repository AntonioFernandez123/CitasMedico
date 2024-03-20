namespace GestionCitasMedico.Models
{
    public class Medico : Usuario
    {
        public string numColegiado { get; set; }
        public ICollection<Cita> Citas { get; set; }
        public ICollection<Paciente> Pacientes { get; set; } 
    }
}
