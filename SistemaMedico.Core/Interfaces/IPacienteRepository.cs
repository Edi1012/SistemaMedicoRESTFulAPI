using SistemaMedico.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaMedico.Core.Interfaces
{
    public interface IPacienteRepository
    {
        Task<IEnumerable<Paciente>> GetPacientes();
        Task<Paciente> GetPaciente(int pacienteId);
        Task InsertPaciente(Paciente paciente);
        Task<bool> UpdatePaciente(Paciente paciente);
        Task<bool> DeletePaciente(int Id);
    }
}
