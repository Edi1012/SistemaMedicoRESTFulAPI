using FluentValidation;
using SistemaMedico.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaMedico.Infrastructure.Validators
{
    public class PacienteDtoValidator : AbstractValidator<PacienteDTO>
    {
        public PacienteDtoValidator() 
        {
            RuleFor(pacienteDTO => pacienteDTO.Nombres)
                .NotNull();

            RuleFor(pacienteDTO => pacienteDTO.ApellidoP)
                .NotNull();

            RuleFor(pacienteDTO => pacienteDTO.ApellidoM)
                .NotNull().NotEmpty().WithMessage("Apellido no puede ser vacio");
        }
    }
}
