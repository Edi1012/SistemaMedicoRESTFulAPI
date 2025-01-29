using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace SistemaMedico.Core.Entities
{
    public class Paciente : BaseEntity
    {
        public string Nombres { get; set; }
        public string ApellidoP { get; set; }
        public string ApellidoM { get; set; }
        public ICollection<DoctorPaciente> DoctorPacientes { get; set; } // Add this property
    }
}
