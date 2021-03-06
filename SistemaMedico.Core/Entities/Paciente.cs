using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace SistemaMedico.Core.Entities
{
    public partial class Paciente : BaseEntity
    {
        [Key]
        public string Nombres { get; set; }
        public string ApellidoP { get; set; }
        public string ApellidoM { get; set; }
    }
}
