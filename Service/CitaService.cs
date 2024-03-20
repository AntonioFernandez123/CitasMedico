using AutoMapper;
using GestionCitasMedico.Dto;
using GestionCitasMedico.Models;
using GestionCitasMedico.Repository;
using GestionCitasMedico.Service.interfaces;

namespace GestionCitasMedico.Service
{
    public class CitaService : ICitaService
    {
        private readonly UnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CitaService(UnitOfWork context, IMapper mapper)
        {
            _unitOfWork = context;
            _mapper = mapper;
        }

        public IEnumerable<CitaDTO> GetCita()
        {
            return _mapper.Map<IEnumerable<CitaDTO>>(_unitOfWork.Citas.GetAllAsync().Result);
        }

        public CitaDTO GetCita(int id)
        {
            return _mapper.Map<CitaDTO>(_unitOfWork.Citas.GetByIdAsync(id).Result);
        }
        
        public async Task<CitaDTO?> UpdateCita(int id, CitaDTO cita)
        {
            var cit = await _unitOfWork.Citas.GetByIdAsync(id);
            if (cit == null)
            {
                return null;
            }

            cit.fechaHora = cita.fechaHora;
            cit.motivoCita = cita.motivoCita;
            cit.idMedico = cita.idMedico;
            cit.idPaciente = cita.idPaciente;

            cit.Diagnostico.valoracionEspecialista = cita.Diagnostico.valoracionEspecialista;
            cit.Diagnostico.enfermedad = cita.Diagnostico.enfermedad;

            await _unitOfWork.Citas.UpdateAsync(cit);
            await _unitOfWork.SaveChangesAsync();
            return _mapper.Map<CitaDTO?>(cit);
        }

        public async Task<CitaDTO> CreateCita(CitaDTO cita)
        {
            var medico = await _unitOfWork.Medicos.GetByIdAsync(cita.idMedico);
            var paciente = await _unitOfWork.Pacientes.GetByIdAsync(cita.idPaciente);
            if (medico == null)
            {
                return null;
            }
            if(paciente == null)
            {
                return null;
            }

            medico.Pacientes.Add(paciente);
            await _unitOfWork.Medicos.UpdateAsync(medico);
            paciente.Medicos.Add(medico);
            await _unitOfWork.Pacientes.UpdateAsync(paciente);

            var cit = _mapper.Map<Cita>(cita);
            await _unitOfWork.Citas.AddAsync(cit);
            await _unitOfWork.SaveChangesAsync();
            return _mapper.Map<CitaDTO>(cita);
        }

        public async Task<bool> DeleteCita(int id)
        {
            var cita = await _unitOfWork.Citas.GetByIdAsync(id);
            if (cita == null)
            {
                return false;
            }

            await _unitOfWork.Citas.DeleteAsync(cita);
            await _unitOfWork.SaveChangesAsync();

            return true;
        }
    }
}
