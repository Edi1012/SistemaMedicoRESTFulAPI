using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaMedico.Core.DTOs
{
    public class PacienteDTO
    {
        public int Id { get; set; }
        public string Nombres { get; set; }
        public string ApellidoP { get; set; }
        public string ApellidoM { get; set; }
    }
}
