using GestionCitasMedico.Models;
using Microsoft.EntityFrameworkCore;

namespace GestionCitasMedico.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) 
        { 

        } 
        public DbSet <Cita> Cita { get; set; }
        public DbSet<Diagnostico> Diagnostico { get; set; }
        public DbSet<Medico> Medico { get; set; }
        public DbSet<Paciente> Paciente { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Medico>()
                .HasMany(pac => pac.Pacientes)
                .WithMany(mec => mec.Medicos)
                .UsingEntity(tab => tab.ToTable("MedicoPaciente"));

            modelBuilder.Entity<Cita>()
                .HasOne(c => c.Medico)
                .WithMany(m => m.Citas)
                .HasForeignKey(c => c.idMedico);

            modelBuilder.Entity<Cita>()
                .HasOne(c => c.Paciente)
                .WithMany(m => m.Citas)
                .HasForeignKey(c => c.idPaciente);

            modelBuilder.Entity<Diagnostico>()
                .HasOne(mp => mp.Cita)
                .WithOne(dp => dp.Diagnostico)
                .HasForeignKey<Cita>(dp => dp.Id);
        }

    }
}
