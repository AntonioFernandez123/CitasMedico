using AutoMapper;
using GestionCitasMedico.Dto;
using GestionCitasMedico.Models;

namespace GestionCitasMedico.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            CreateMap<Medico, MedicoDTO>();
            CreateMap<MedicoDTO, Medico>();
            CreateMap<Medico, MedicoResponse>();

            CreateMap<Paciente, PacienteDTO>();
            CreateMap<PacienteDTO, Paciente>();
            CreateMap<Paciente, PacienteResponse>();


            CreateMap<Cita, CitaDTO>();
            CreateMap<CitaDTO, Cita>();

            CreateMap<Diagnostico, DiagnosticoDTO>();
            CreateMap<DiagnosticoDTO, Diagnostico>();
        } 
    }
}
