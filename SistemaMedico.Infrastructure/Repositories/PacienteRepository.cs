﻿using Microsoft.EntityFrameworkCore;
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
            sistemaMedicoContext.SaveChangesAsync();
        }
    }
}