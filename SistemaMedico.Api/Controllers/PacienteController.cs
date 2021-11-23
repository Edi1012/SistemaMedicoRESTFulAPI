using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaMedico.Api.Response;
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
        private readonly IPacienteService _pacienteService;
        private readonly IMapper mapper;

        public PacienteController(IPacienteService pacienteService, IMapper mapper) 
        {
            this._pacienteService = pacienteService;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetPacientes() 
        {
            var pacientes = await _pacienteService.GetPacientes();
            var pacientesDto = mapper.Map<IEnumerable<PacienteDTO>>(pacientes);
            var response = new ApiResponse<IEnumerable<PacienteDTO>>(pacientesDto);
            return Ok(response);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetPaciente(int Id)
        {
            var paciente = await _pacienteService.GetPaciente(Id);
            var pacienteDto = mapper.Map<PacienteDTO>(paciente);
            var response = new ApiResponse<PacienteDTO>(pacienteDto);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> InsertPaciente(PacienteDTO pacienteDto)
        {
            var paciente = mapper.Map<Paciente>(pacienteDto);
            await _pacienteService.InsertPaciente(paciente);
            var response = new ApiResponse<Paciente>(paciente);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> ActualizarPaciente(int Id, PacienteDTO pacienteDto)
        {
            var paciente = mapper.Map<Paciente>(pacienteDto);
            paciente.Id = Id;
            await _pacienteService.UpdatePaciente(paciente);
            var response = new ApiResponse<Paciente>(paciente);
            return Ok(response);
        }


        [HttpDelete]
        public async Task<IActionResult> DeletePaciente(int Id)
        {
            var result = await _pacienteService.DeletePaciente(Id);
            var response = new ApiResponse<bool>(result);
            return Ok(response);
        }
    }
}
