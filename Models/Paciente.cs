namespace GestionCitasMedico.Models
{
    public class Paciente : Usuario
    {
        public string NSS { get; set; }
        public string numTarjeta { get; set; }
        public string telefono { get; set; }
        public string direccion { get; set; }
        public ICollection<Cita> Citas { get; set; }
        public ICollection<Medico> Medicos { get; set; }

    }
}
