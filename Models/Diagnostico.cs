using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace GestionCitasMedico.Models
{
    public class Diagnostico
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string valoracionEspecialista { get; set; }
        public string enfermedad { get; set; }
        public virtual Cita Cita { get; set; }
    }
}
