using AutoMapper;
using SistemaMedico.Core.DTOs;
using SistemaMedico.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaMedico.Infrastructure.Mapping
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile() 
        {
            CreateMap<Paciente, PacienteDTO>();
            CreateMap<PacienteDTO, Paciente>();
        }
    }
}
