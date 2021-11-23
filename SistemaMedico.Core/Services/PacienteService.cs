using SistemaMedico.Core.Entities;
using SistemaMedico.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaMedico.Core.Services
{

    /// <summary>
    /// Aqui van las reglas de negocio
    /// </summary>
    public class PacienteService : IPacienteService
    {
        private readonly IPacienteRepository pacienteRepository;

        public PacienteService(IPacienteRepository pacienteRepository)
        {
            this.pacienteRepository = pacienteRepository;
        }

        public async Task<bool> DeletePaciente(int Id)
        {
            return await pacienteRepository.DeletePaciente(Id);
        }

        public async Task<Paciente> GetPaciente(int pacienteId)
        {
            return await pacienteRepository.GetPaciente(pacienteId);
        }

        public async Task<IEnumerable<Paciente>> GetPacientes()
        {
            return await pacienteRepository.GetPacientes();
        }

        public async Task InsertPaciente(Paciente paciente)
        {
            await pacienteRepository.InsertPaciente(paciente);
        }

        public async Task<bool> UpdatePaciente(Paciente paciente)
        {
            return await pacienteRepository.UpdatePaciente(paciente);
        }
    }
}
