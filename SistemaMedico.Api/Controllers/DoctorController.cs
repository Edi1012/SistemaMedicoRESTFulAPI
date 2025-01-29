using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SistemaMedico.Core.DTOs;
using SistemaMedico.Core.Entities;
using SistemaMedico.Core.Interfaces;
using SistemaMedico.Api.Response;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SistemaMedico.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private readonly IDoctorService _doctorService;
        private readonly IMapper _mapper;

        public DoctorController(IDoctorService doctorService, IMapper mapper)
        {
            _doctorService = doctorService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetDoctores()
        {
            var doctores = await _doctorService.GetDoctores();
            var doctoresDto = _mapper.Map<IEnumerable<DoctorDTO>>(doctores);
            var response = new ApiResponse<IEnumerable<DoctorDTO>>(doctoresDto);
            return Ok(response);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetDoctor(int Id)
        {
            var doctor = await _doctorService.GetDoctor(Id);
            var doctorDto = _mapper.Map<DoctorDTO>(doctor);
            var response = new ApiResponse<DoctorDTO>(doctorDto);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> InsertDoctor(DoctorDTO doctorDto)
        {
            var doctor = _mapper.Map<Doctor>(doctorDto);
            await _doctorService.InsertDoctor(doctor);
            var response = new ApiResponse<Doctor>(doctor);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateDoctor(int Id, DoctorDTO doctorDto)
        {
            var doctor = _mapper.Map<Doctor>(doctorDto);
            doctor.Id = Id;
            await _doctorService.UpdateDoctor(doctor);
            var response = new ApiResponse<Doctor>(doctor);
            return Ok(response);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteDoctor(int Id)
        {
            var result = await _doctorService.DeleteDoctor(Id);
            var response = new ApiResponse<bool>(result);
            return Ok(response);
        }
    }
}
