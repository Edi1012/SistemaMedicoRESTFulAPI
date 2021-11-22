using Microsoft.EntityFrameworkCore;
using SistemaMedico.Core.Entities;
using SistemaMedico.Core.Interfaces;
using SistemaMedico.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaMedico.Infrastructure.Repositories
{
    public class PacienteRepository : IPacienteRepository
    {
        private readonly SistemaMedicoContext sistemaMedicoContext;

        public PacienteRepository(SistemaMedicoContext _sistemaMedicoContext) 
        {
            this.sistemaMedicoContext = _sistemaMedicoContext;
        }

        public async Task<IEnumerable<Paciente>> GetPacientes() 
        {
            var pacientes = await sistemaMedicoContext.Pacientes.ToListAsync();
            return pacientes.ToList();
        }

        public async Task<Paciente> GetPaciente(int pacienteId)
        {
            var paciente = await sistemaMedicoContext.Pacientes.FirstOrDefaultAsync(_paciente => _paciente.Id == pacienteId );
            return paciente;
        }

        public async Task InsertPaciente(Paciente paciente)
        {
            sistemaMedicoContext.Pacientes.Add(paciente);
            await sistemaMedicoContext.SaveChangesAsync();
        }

        public async Task<bool> UpdatePaciente(Paciente paciente)
        {
            var currentPost = await  GetPaciente(paciente.Id);

            currentPost.Nombres = paciente.Nombres;
            currentPost.ApellidoP = paciente.ApellidoP;
            currentPost.ApellidoM = paciente.ApellidoM;

            int rows = await sistemaMedicoContext.SaveChangesAsync();

            return rows > 0;
        }


        public async Task<bool> DeletePaciente(int Id)
        {
            var currentPaciente = await GetPaciente(Id);

            sistemaMedicoContext.Pacientes.Remove(currentPaciente);
            int rows = await sistemaMedicoContext.SaveChangesAsync();

            return rows > 0;
        }
    }
}
