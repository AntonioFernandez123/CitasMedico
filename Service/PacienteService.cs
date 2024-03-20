using AutoMapper;
using GestionCitasMedico.Dto;
using GestionCitasMedico.Models;
using GestionCitasMedico.Repository;
using GestionCitasMedico.Service.interfaces;

namespace GestionCitasMedico.Service
{
    public class PacienteService : IPacienteService
    {
        private readonly UnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PacienteService(UnitOfWork context, IMapper mapper)
        {
            _unitOfWork = context;
            _mapper = mapper;
        }

        public IEnumerable<PacienteResponse> GetPaciente()
        {
            return _mapper.Map<IEnumerable<PacienteResponse>>(_unitOfWork.Pacientes.GetAllAsync().Result);
        }

        public PacienteResponse GetPaciente(int id)
        {
            return _mapper.Map<PacienteResponse>(_unitOfWork.Pacientes.GetByIdAsync(id).Result);
        }

        public async Task<PacienteDTO?> UpdatePaciente(int id, PacienteDTO paciente)
        {
            var pac = await _unitOfWork.Pacientes.GetByIdAsync(id);
            if (pac == null)
            {
                return null;
            }

            pac.Nombre = paciente.Nombre;
            pac.Apellidos = paciente.Apellidos;
            pac.usuario = paciente.usuario;
            pac.Clave = paciente.Clave;

            pac.NSS = paciente.NSS;
            pac.numTarjeta = paciente.numTarjeta;
            pac.telefono = paciente.telefono;
            pac.direccion = paciente.direccion;

            await _unitOfWork.Pacientes.UpdateAsync(pac);
            await _unitOfWork.SaveChangesAsync();
            return _mapper.Map<PacienteDTO?>(pac);
        }
        public async Task<PacienteDTO> CreatePaciente(PacienteDTO paciente)
        {
            var pac = _mapper.Map<Paciente>(paciente);
            await _unitOfWork.Pacientes.AddAsync(pac);
            await _unitOfWork.SaveChangesAsync();
            return _mapper.Map<PacienteDTO>(paciente);
        }
        public async Task<bool> DeletePaciente(int id)
        {
            var paciente = await _unitOfWork.Pacientes.GetByIdAsync(id);
            if (paciente == null)
            {
                return false;
            }

            await _unitOfWork.Pacientes.DeleteAsync(paciente);
            await _unitOfWork.SaveChangesAsync();

            return true;
        }
    }
}
