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
        private readonly IRepository<Paciente> pacienteRepository;

        public PacienteService(IRepository<Paciente> pacienteRepository)
        {
            this.pacienteRepository = pacienteRepository;
        }


        public async Task<IEnumerable<Paciente>> GetPacientes()
        {
            return await pacienteRepository.GetAll();
        }


        public async Task<Paciente> GetPaciente(int pacienteId)
        {
            return await pacienteRepository.GetById(pacienteId);
        }
        public async Task InsertPaciente(Paciente paciente)
        {
            await pacienteRepository.Add(paciente);
        }
        public async Task<bool> UpdatePaciente(Paciente paciente)
        {
            await pacienteRepository.Update(paciente);
            return true;
        }
        public async Task<bool> DeletePaciente(int Id)
        {
            await pacienteRepository.Delete(Id);
            return true;
        }


     
    }
}
