using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SistemaMedico.Core.Entities
{
    public class Doctor : BaseEntity
    {
        public string Nombre { get; set; }
        public string ApellidoP { get; set; }
        public string ApellidoM { get; set; }
        public string Especialidad { get; set; }

        public ICollection<DoctorPaciente> DoctorPacientes { get; set; }
    }

    public class DoctorPaciente
    {
        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; }

        public int PacienteId { get; set; }
        public Paciente Paciente { get; set; }
    }
}
