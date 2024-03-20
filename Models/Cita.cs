using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestionCitasMedico.Models
{
    public class Cita
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public DateTime fechaHora { get; set; }
        public string motivoCita { get; set; }
        public Medico Medico { get; set; }
        public int idMedico { get; set; }
        public Paciente Paciente { get; set; }
        public int idPaciente { get; set; }
        public virtual Diagnostico Diagnostico { get; set; }
    }
}
