using AutoMapper;
using GestionCitasMedico.Dto;
using GestionCitasMedico.Models;
using GestionCitasMedico.Repository;
using GestionCitasMedico.Service.interfaces;

namespace GestionCitasMedico.Service
{
    public class MedicoService : IMedicoService
    {
        private readonly UnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public MedicoService(UnitOfWork context, IMapper mapper)
        {
            _unitOfWork = context;
            _mapper = mapper;
        }
        public IEnumerable<MedicoResponse> GetMedico()
        {
            return _mapper.Map<IEnumerable<MedicoResponse>>(_unitOfWork.Medicos.GetAllAsync().Result);
        }

        public MedicoResponse GetMedico(int id)
        {
            return _mapper.Map<MedicoResponse>(_unitOfWork.Medicos.GetByIdAsync(id).Result);
        }

        public async Task<MedicoDTO?> UpdateMedico(int id, MedicoDTO medico)
        {
            var med = await _unitOfWork.Medicos.GetByIdAsync(id);
            if (med == null)
            {
                return null;
            }

            med.Nombre = medico.Nombre;
            med.Apellidos = medico.Apellidos;
            med.usuario = medico.usuario;
            med.Clave = medico.Clave;

            med.numColegiado = medico.numColegiado;

            await _unitOfWork.Medicos.UpdateAsync(med);
            await _unitOfWork.SaveChangesAsync();
            return _mapper.Map<MedicoDTO?>(med);
        }

        public async Task<MedicoDTO> CreateMedico(MedicoDTO medico)
        {
            var med = _mapper.Map<Medico>(medico);
            await _unitOfWork.Medicos.AddAsync(med);
            await _unitOfWork.SaveChangesAsync();
            return _mapper.Map<MedicoDTO>(medico);
        }

        public async Task<bool> DeleteMedico(int id)
        {
            var medico = await _unitOfWork.Medicos.GetByIdAsync(id);
            if (medico == null)
            {
                return false;
            }

            await _unitOfWork.Medicos.DeleteAsync(medico);
            await _unitOfWork.SaveChangesAsync();

            return true;
        }
    }
}
