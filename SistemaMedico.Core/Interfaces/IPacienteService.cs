using SistemaMedico.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SistemaMedico.Core.Interfaces
{
    public interface IPacienteService
    {
        Task<IEnumerable<Paciente>> GetPacientes();
        Task<Paciente> GetPaciente(int pacienteId);
        Task InsertPaciente(Paciente paciente);
        Task<bool> UpdatePaciente(Paciente paciente);
        Task<bool> DeletePaciente(int Id);
    }
}