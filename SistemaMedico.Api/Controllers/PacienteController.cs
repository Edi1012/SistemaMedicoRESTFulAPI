using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaMedico.Core.DTOs;
using SistemaMedico.Core.Entities;
using SistemaMedico.Core.Interfaces;
using SistemaMedico.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaMedico.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PacienteController : ControllerBase
    {
        private readonly IPacienteRepository _pacienteRepository;
        private readonly IMapper mapper;

        public PacienteController(IPacienteRepository pacienteRepository, IMapper mapper) 
        {
            this._pacienteRepository = pacienteRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetPacientes() 
        {
            var pacientes = await _pacienteRepository.GetPacientes();
            var pacientesDto = mapper.Map<IEnumerable<PacienteDTO>>(pacientes);
            return Ok(pacientesDto);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetPaciente(int Id)
        {
            var paciente = await _pacienteRepository.GetPaciente(Id);
            var pacienteDto = mapper.Map<PacienteDTO>(paciente);
            return Ok(pacienteDto);
        }

        [HttpPost]
        public async Task<IActionResult> InsertPaciente(PacienteDTO pacienteDto)
        {
            var paciente = mapper.Map<Paciente>(pacienteDto);
            await _pacienteRepository.InsertPaciente(paciente);
            return Ok(paciente);
        }

        [HttpPut]
        public async Task<IActionResult> ActualizarPaciente(int Id, PacienteDTO pacienteDto)
        {
            var paciente = mapper.Map<Paciente>(pacienteDto);
            await _pacienteRepository.UpdatePaciente(paciente);
            return Ok(paciente);
        }


        [HttpDelete]
        public async Task<IActionResult> DeletePaciente(int Id, PacienteDTO pacienteDto)
        {
            var paciente = mapper.Map<Paciente>(pacienteDto);
            paciente.Id = Id;
            await _pacienteRepository.DeletePaciente(paciente);
            return Ok(paciente);
        }
    }
}
